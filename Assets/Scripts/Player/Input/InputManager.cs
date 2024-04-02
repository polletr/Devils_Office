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
    [SerializeField]
    InputDevice playerInputDevice;
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
    private void SeanFix()
    {
        action = new PlayerInput();
        if(playerNumber == 0)
        {
            action.Player.Move.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(true); };
            action.Player.Move.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(false); };
            action.Player.TurnRight.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleRotate(90); };
            action.Player.TurnLeft.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleRotate(-90); };
            action.Player.InteractKill.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleInteract(); };
            action.Player.InteractKill.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleStopInteract(); };
            action.Player.ViewTask.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleViewTask(true); };
            action.Player.ViewTask.canceled += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleViewTask(false); };
        }
        else if (playerNumber == 1)
        {
            action.Player2.Move.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleMove(true); };
            action.Player2.Move.canceled += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleMove(false); };
            action.Player2.TurnRight.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleRotate(90); };
            action.Player2.TurnLeft.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleRotate(-90); };
            action.Player2.InteractKill.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleInteract(); };
            action.Player2.InteractKill.canceled += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleStopInteract(); };
            action.Player2.ViewTask.performed += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleViewTask(true); };
            action.Player2.ViewTask.canceled += (val) => { if (val.control.device == InputSystem.devices[0]) player.HandleViewTask(false); };
        }
        else
        {
            action.GamePad.Move.performed += (val) => { if (val.control.device == InputSystem.devices[playerNumber]) player.HandleMove(true); };
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
        SeanFix();
        action.Enable();
        return;
       /* if (player.controlScheme == "P0")
        {
            action.Player.Move.performed += (val) => player.HandleMove();
            action.Player.TurnRight.performed += (val) => player.HandleRotate(90);
            action.Player.TurnLeft.performed += (val) => player.HandleRotate(-90);

            action.Player.InteractKill.performed += (val) => player.HandleInteract();
            action.Player.InteractKill.canceled += (val) => player.HandleStopInteract();

            action.Player.ViewTask.performed += (val) => player.HandleViewTask(true);
            action.Player.ViewTask.canceled += (val) => player.HandleViewTask(false);

        }
        else if (player.controlScheme == "P1")
        {
            action.Player2.Move.performed += (val) => player.HandleMove();
            action.Player2.TurnRight.performed += (val) => player.HandleRotate(90);
            action.Player2.TurnLeft.performed += (val) => player.HandleRotate(-90);

            action.Player2.InteractKill.performed += (val) => player.HandleInteract();
            action.Player2.InteractKill.canceled += (val) => player.HandleStopInteract();

            action.Player2.ViewTask.performed += (val) => player.HandleViewTask(true);
            action.Player2.ViewTask.canceled += (val) => player.HandleViewTask(false);
        }
        else if (player.controlScheme == "P2" )
        {
            action.Player3.Move.performed += (val) => player.HandleMove();
            action.Player3.TurnRight.performed += (val) => player.HandleRotate(90);
            action.Player3.TurnLeft.performed += (val) => player.HandleRotate(-90);

            action.Player3.InteractKill.performed += (val) => player.HandleInteract();
            action.Player3.InteractKill.canceled += (val) => player.HandleStopInteract();


            action.Player3.ViewTask.performed += (val) => player.HandleViewTask(true);
            action.Player3.ViewTask.canceled += (val) => player.HandleViewTask(false);
        }
        else if (player.controlScheme == "P3")
        {
            action.Player4.Move.performed += (val) => player.HandleMove();
            action.Player4.TurnRight.performed += (val) => player.HandleRotate(90);
            action.Player4.TurnLeft.performed += (val) => player.HandleRotate(-90);

            action.Player4.InteractKill.performed += (val) => player.HandleInteract();
            action.Player4.InteractKill.canceled += (val) => player.HandleStopInteract();


            action.Player4.ViewTask.performed += (val) => player.HandleViewTask(true);
            action.Player4.ViewTask.canceled += (val) => player.HandleViewTask(false);
        }

        else
        {
            Invoke("WaitTimer", 0.1f);
        }

      */
    }

    private void OnDisable()
    {
        action.Player.Move.performed -= (val) => player.HandleMove(false);
        action.Player.Move.canceled -= (val) => player.HandleMove(false);

        action.Player.TurnRight.performed -= (val) => player.HandleRotate(90);
        action.Player.TurnLeft.performed -= (val) => player.HandleRotate(-90);

        action.Player.InteractKill.performed += (val) => player.HandleInteract();
        action.Player.InteractKill.canceled += (val) => player.HandleStopInteract();

        action.Player.ViewTask.performed += (val) => player.HandleViewTask(false);


        action.Disable();
    }

    private void WaitTimer()
    {
        action.Disable();
        OnEnable();
    }

}
