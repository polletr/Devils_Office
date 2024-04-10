using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    InputControls action;
    PlayerController player { get; set; }
    Vector2 _rotate;
    [SerializeField]
    public int playerNumber;
    [SerializeField]
    InputDevice playerInputDevice;

    private PlayerInput _playerInput;

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
        _playerInput = GetComponent<PlayerInput>();

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
        action = new InputControls();

        if (playerNumber == 0)
        {
            _playerInput.defaultActionMap = "KeyboardLeft";
            _playerInput.SwitchCurrentControlScheme("KBLeft", Keyboard.current);
            action.devices = new[] { ControllerManager.Instance.devices[0] };

            action.KeyboardLeft.Move.performed += (val) => { player.HandleMove(true); Debug.Log("Move"); };
            action.KeyboardLeft.Move.canceled += (val) => { player.HandleMove(false); };
            action.KeyboardLeft.TurnRight.performed += (val) => { player.HandleRotate(90); };
            action.KeyboardLeft.TurnLeft.performed += (val) => { player.HandleRotate(-90); };
            action.KeyboardLeft.InteractKill.performed += (val) => { player.HandleInteract(); };
            action.KeyboardLeft.InteractKill.canceled += (val) => { player.HandleStopInteract(); };
            action.KeyboardLeft.ViewTask.performed += (val) => { player.HandleViewTask(true); };
            action.KeyboardLeft.ViewTask.canceled += (val) => { player.HandleViewTask(false); };
            
        }
        else if (playerNumber == 1)
        {
            _playerInput.defaultActionMap = "KeyboardRight";
            _playerInput.SwitchCurrentControlScheme("KBRight", Keyboard.current);
            action.devices = new[] { ControllerManager.Instance.devices[0] };

            action.KeyboardRight.Move.performed += (val) => { player.HandleMove(true); Debug.Log("Move"); };
            action.KeyboardRight.Move.canceled += (val) => { player.HandleMove(false); };
            action.KeyboardRight.TurnRight.performed += (val) => { player.HandleRotate(90); };
            action.KeyboardRight.TurnLeft.performed += (val) => { player.HandleRotate(-90); };
            action.KeyboardRight.InteractKill.performed += (val) => { player.HandleInteract(); };
            action.KeyboardRight.InteractKill.canceled += (val) => { player.HandleStopInteract(); };
            action.KeyboardRight.ViewTask.performed += (val) => { player.HandleViewTask(true); };
            action.KeyboardRight.ViewTask.canceled += (val) => { player.HandleViewTask(false); };
            
        }
        else
        {
            _playerInput.defaultActionMap = "GamePad";
            _playerInput.SwitchCurrentControlScheme("GamePad", Gamepad.current);
            action.devices = new[] { ControllerManager.Instance.devices[playerNumber] };

            action.GamePad.Move.performed += (val) => { player.HandleMove(true); Debug.Log("Move"); };
            action.GamePad.Move.canceled += (val) => { player.HandleMove(false); };
            action.GamePad.TurnRight.performed += (val) => { player.HandleRotate(90); };
            action.GamePad.TurnLeft.performed += (val) => { player.HandleRotate(-90); };
            action.GamePad.InteractKill.performed += (val) => { player.HandleInteract(); };
            action.GamePad.InteractKill.canceled += (val) => {  player.HandleStopInteract(); };
            action.GamePad.ViewTask.performed += (val) => { player.HandleViewTask(true); };
            action.GamePad.ViewTask.canceled += (val) => { player.HandleViewTask(false); };
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
