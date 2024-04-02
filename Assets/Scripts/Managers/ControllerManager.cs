using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerManager : Singleton<ControllerManager>
{

    public List<Image> smallControlsImages = new();
    public List<Image> controlsImages = new();

    public Image currentControl;
    public Image controlDescription;

    public List<InputDevice> inputDevices = new();
    private Dictionary<int, Image> inputSmallImages = new();
    private Dictionary<int, Image> inputImages = new();
    private Dictionary<int, InputDevice> inputDevice = new();


    private void Awake()
    {
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Keyboard keyboard)
            {
                inputSmallImages.Add(, controlsImages[0]);




                playerControls.Add(device, controlsImages[1]);
            }
            else if (device is Gamepad)
            {
                playerControls.Add(device, controlsImages[2]);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
