using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;
using UnityEngine.TextCore.Text;

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
    public GameObject blackScreen;
    /*    private Dictionary<int, Sprite> inputIcon = new();
        private Dictionary<int, Sprite> inputImages = new();
        private Dictionary<int, InputDevice> inputDevice = new();
    */
    private int gamepadIndex;

    private int activationGamepadIndex;

    [HideInInspector]
    public Dictionary<int, int> playerDevice = new();

    private Dictionary<int, bool> playerReady = new();
    private Dictionary<InputDevice, int> inputDevice = new();


    private bool playEnabled;

    private int player = 0;

    public UnityEvent StartGame;
    public UnityEvent ShowStory;

    float timer = 0f;

    bool holdToSkip = false;

    [SerializeField]
    float storyTimer = 30f;

    [SerializeField]
    private Image loaderImageUI;

    private void Awake()
    {
        AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.welcomeToHell);

        foreach (Image Controls in UIControlDescription)
        {
            if (missingControllerImage != null)
                Controls.sprite = missingControllerImage;
        }
        CheckDevices();
    }

    private void Update()
    {
        if (playerReady.Count >= 2)
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
            ShowStory.Invoke();

            if (!holdToSkip)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer += 5f * Time.deltaTime;
            }

            LoadingBar(timer, storyTimer);

            if (timer > storyTimer)
            {
                StartGame.Invoke();
            }
            Debug.Log(timer);
        }

    }

    public void LoadingBar(float indicator, float maxIndicator)
    {
        loaderImageUI.fillAmount = indicator / maxIndicator;
    }


    private void ActivateController(int index)
    {
        if (!playerDevice.ContainsValue(index))
        {
            playerDevice.Add(player, index);
            playerReady.Add(index, false);

            UIControlDescription[player].sprite = controlsImages[Mathf.Min(index, 2)];

            player++;
        }
        else if (playerDevice.ContainsValue(index) && !playEnabled)
        {
            playerReady[index] = true;
            foreach (int key in playerDevice.Keys)
            {
                if (playerDevice[key] == index)
                {
                    UIReadyCheck[key].gameObject.SetActive(true);
                }
            }
        }
        else
        {
            holdToSkip = true;
        }

    }

    private void CancelSkip()
    {
        if (holdToSkip)
            holdToSkip = false;

    }


    private void CheckDevices()
    {
        gamepadIndex = 0;
        activationGamepadIndex = 0;
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Gamepad gamepad)
            {
                inputDevice.Add(device, 2 + gamepadIndex);
                gamepadIndex++;

            }
        }
        
    }


    private void OnEnable()
    {
        action = new PlayerInput();
        action.KeyboardLeft.Move.performed += (val) => ActivateController(0);
        action.KeyboardLeft.Move.canceled += (val) => CancelSkip();

        action.KeyboardRight.Move.performed += (val) => ActivateController(1);
        action.KeyboardRight.Move.canceled += (val) => CancelSkip();

        action.GamePad.Move.performed += (val) => ActivateController(inputDevice[val.control.device]);
        action.GamePad.Move.canceled += (val) => CancelSkip();

        action.Enable();
        return;



    }

    private void OnDisable()
    {
        action.Disable();


    }

    public void BlackScreen()
    {
        blackScreen.SetActive(true);
        Invoke("DisableBlackScreen", 0.1f);
      
    }
    public void DisableBlackScreen()
    {
        blackScreen.SetActive(false);
    }

}
