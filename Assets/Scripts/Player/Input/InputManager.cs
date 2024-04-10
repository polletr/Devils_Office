using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    PlayerInput action;
    PlayerController player { get; set; }
    Vector2 _rotate;
    [SerializeField]
    public int playerNumber;

    public Vector2 Rotate
    {
        get
        {
            return _rotate;
        }
        private set
        {
            _rotate = value;
        }
    }

    void Awake()
    {
        player = GetComponent<PlayerController>();

    }

    private void Update()
    {
      /*  var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Keyboard keyboard)
            {
                
            }
            else if (device is Gamepad)
            {

            }
        }*/
    }
    private void HandleInput()
    {
        action = new PlayerInput();
        if(playerNumber == 0)
        {
            action.KeyboardLeft.Move.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(true); Debug.Log("Actual Control:" + val.control.device); Debug.Log(InputSystem.devices[playerNumber]); };
            action.KeyboardLeft.Move.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(false); };
            action.KeyboardLeft.TurnRight.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleRotate(90); };
            action.KeyboardLeft.TurnLeft.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleRotate(-90); };
            action.KeyboardLeft.InteractKill.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleInteract(); };
            action.KeyboardLeft.InteractKill.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleStopInteract(); };
            action.KeyboardLeft.ViewTask.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleViewTask(true); };
            action.KeyboardLeft.ViewTask.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleViewTask(false); };
        }
        else if (playerNumber == 1)
        {
            action.KeyboardRight.Move.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleMove(true); Debug.Log("Actual Control:" + val.control.device); Debug.Log(InputSystem.devices[playerNumber]); };
            action.KeyboardRight.Move.canceled += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleMove(false); };
            action.KeyboardRight.TurnRight.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleRotate(90); };
            action.KeyboardRight.TurnLeft.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleRotate(-90); };
            action.KeyboardRight.InteractKill.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleInteract(); };
            action.KeyboardRight.InteractKill.canceled += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleStopInteract(); };
            action.KeyboardRight.ViewTask.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleViewTask(true); };
            action.KeyboardRight.ViewTask.canceled += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleViewTask(false); };
        }
        else
        {
            action.GamePad.Move.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(true); Debug.Log("Actual Control:" + val.control.device); Debug.Log("Device Check:" + InputSystem.devices[playerNumber]); };
            action.GamePad.Move.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(false); };
            action.GamePad.TurnRight.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleRotate(90); };
            action.GamePad.TurnLeft.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleRotate(-90); };
            action.GamePad.InteractKill.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleInteract(); };
            action.GamePad.InteractKill.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleStopInteract(); };
            action.GamePad.ViewTask.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleViewTask(true); };
            action.GamePad.ViewTask.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleViewTask(false); };
        }



    }
    private void OnEnable()
    {
        var devices = InputSystem.devices;
        foreach (var item in devices)
        {
            Debug.Log(item.description);

        }
        HandleInput();
        action.Enable();
        return;
    }

    private void OnDisable()
    {
       
        action.Disable();
    }

    private void WaitTimer()
    {
        action.Disable();
        OnEnable();
    }

}
