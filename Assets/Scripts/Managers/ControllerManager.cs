using UnityEngine.InputSystem;

public class ControllerManager : Singleton<ControllerManager>
{
    private void Awake()
    {
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Keyboard keyboard)
            {

            }
            else if (device is Gamepad)
            {

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
