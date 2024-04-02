using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UI;

public class ControllerManager : Singleton<ControllerManager>
{

    public List<Image> controlsImages = new();
    public Image currentControl;
    public Image controlDescription;

    public List<InputDevice> inputDevices =  new();

    private void Awake()
    {
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Keyboard keyboard)
            {
                inputDevices.Add(device);
                inputDevices.Add(device);
            }
            else if (device is Gamepad)
            {
                inputDevices.Add(device);
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
