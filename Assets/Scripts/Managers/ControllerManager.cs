using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class ControllerManager : Singleton<ControllerManager>
{
    PlayerInput action;

    //public List<Sprite> controlsIcons = new();
    public List<Sprite> controlsImages = new();

    public Sprite missingControllerImage;
    //public Sprite missingControllerIcon;

    public GameObject controlSelection;

    //public Image[] UIPlayerControl;
    public Image[] UIControlDescription;

    public Image[] UIReadyCheck;

    /*    private Dictionary<int, Sprite> inputIcon = new();
        private Dictionary<int, Sprite> inputImages = new();
        private Dictionary<int, InputDevice> inputDevice = new();
    */
    private int gamepadIndex;

    private int activationGamepadIndex;

    [HideInInspector]
    public Dictionary<int, int> playerDevice = new();

    private Dictionary<int, bool> playerReady = new();


    private bool playEnabled;

    private int i = 0;

    public UnityEvent StartGame;

    private void Awake()
    {
        foreach (Image Controls in UIControlDescription)
        {
            if (missingControllerImage != null)
            Controls.sprite = missingControllerImage;
        }

        CheckDevices();
    }

    private void Update()
    {
        if (UIControlDescription.Length == playerReady.Count)
        {
            if (playerReady.ContainsValue(false))
            {
                playEnabled = false;
            }
            else
            {
                playEnabled = true;
            }
        }

        if (playEnabled)
        {
            StartGame.Invoke();
        }
    }

    private void ActivateController(int index)
    {
        if (UIControlDescription.Length > i)
        {
            if (!playerDevice.ContainsValue(index))
            {
                playerDevice.Add(i, index);
                playerReady.Add(index, false);

                UIControlDescription[i].sprite = controlsImages[Mathf.Min(index, 2)];

                i++;
            }
        }
        else
        {
            playerReady[index] = true;
        }


    }


    private void CheckDevices()
    {
/*        gamepadIndex = 0;
        activationGamepadIndex = 0;
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Keyboard keyboard)
            {
                inputIcon.Add(0, controlsIcons[0]);
                inputIcon.Add(1, controlsIcons[1]);
                inputImages.Add(0, controlsImages[0]);
                inputImages.Add(1, controlsImages[1]);

                inputDevice.Add(0, device);
                inputDevice.Add(1, device);

            }
            else if (device is Gamepad gamepad)
            {
                inputIcon.Add(2 + gamepadIndex, controlsIcons[2]);
                inputImages.Add(2 + gamepadIndex, controlsImages[2]);
                inputDevice.Add(2 + gamepadIndex, device);
                gamepadIndex++;


            }
        }

        for (int i = 0; i < UIPlayerControl.Length; i++)
        {
            if (inputDevice.Count >= i)
            {
                UIPlayerControl[i].sprite = inputImages[i];
                UIControlDescription[i].sprite = inputIcon[i];
            }
            else
            {
                UIPlayerControl[i].sprite = missingControllerImage;
                UIControlDescription[i].sprite = missingControllerIcon;
            }

        }
*/    }


    private void OnEnable()
    {
        action = new PlayerInput();
        action.KeyboardLeft.Move.performed += (val) => ActivateController(0);
        action.KeyboardRight.Move.performed += (val) => ActivateController(1);


        action.GamePad.Move.performed += (val) => { ActivateController(2 + activationGamepadIndex); activationGamepadIndex++; };
        action.Enable();
        return;



    }


}
