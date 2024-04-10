using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;
using UnityEngine.TextCore.Text;
using TMPro;

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

    [SerializeField]
    private TextMeshProUGUI readyTimerText;

    [HideInInspector]
    public Dictionary<int, int> playerDevice = new();

    private Dictionary<int, bool> playerReady = new();
    private Dictionary<InputDevice, int> inputDevice = new();


    private bool playEnabled;

    private int player = 0;

    public UnityEvent StartGame;
    public UnityEvent ShowStory;

    private float readytimer = 4f;

    private void Awake()
    {

        foreach (Image Controls in UIControlDescription)
        {
            if (missingControllerImage != null)
                Controls.sprite = missingControllerImage;
        }
        CheckDevices();
        readyTimerText.gameObject.SetActive(false);
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
            //Enable UI timer
            readyTimerText.gameObject.SetActive(true);
            int t = (int)readytimer;
            readyTimerText.text = t.ToString();
            readytimer -= Time.deltaTime;
            if (readytimer <= 0f)
            {
                readyTimerText.gameObject.SetActive(false);
                Ready(); 
            }
         
        }
        else
        {
            //Disable Timer UI
            readyTimerText.gameObject.SetActive(false);
            readytimer = 4f;
        }
        

    }

    private void Ready()
    {
        ShowStory.Invoke();

    }


    private void ActivateController(int index)
    {
        if (!playerDevice.ContainsValue(index))
        {
            playerDevice.Add(player, index);
            playerReady.Add(index, false);

            Debug.Log(playerDevice[player]);
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

    }



    private void CheckDevices()
    {
        gamepadIndex = 0;
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

        action.KeyboardRight.Move.performed += (val) => ActivateController(1);

        action.GamePad.Move.performed += (val) => ActivateController(inputDevice[val.control.device]);

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
