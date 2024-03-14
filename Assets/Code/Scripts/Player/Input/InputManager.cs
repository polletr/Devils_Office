using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInput action;
    PlayerController player { get; set; }
    Vector2 _rotate;
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
        action = new PlayerInput();
    }

    private void Update()
    {
        //Check if the player is using the keyboard or the gamepad
        /* var devices = InputSystem.devices;

         foreach (var device in devices)
         {
             // Check if the device is active
             if (device is Gamepad gamepad && gamepad.leftStick.ReadValue() != Vector2.zero)
             {
                 UIGameControlsManager.Instance.SetToGamePadUI();
             }
             else if (device is Keyboard keyboard && (keyboard.anyKey.isPressed || keyboard.anyKey.wasPressedThisFrame))
             {
                UIGameControlsManager.Instance.SetToKeyBoardUI();
             }
         }*/

    }
    private void OnEnable()
    {

        action.Player.Move.performed += (val) => player.HandleMove();
        action.Player.TurnRight.performed += (val) => player.HandleRotate(90);
        action.Player.TurnLeft.performed += (val) => player.HandleRotate(-90);

        action.Player.Kill.performed += (val) => player.HandleAttack();

        action.Player.Interact.performed += (val) => player.HandleInteract();
        action.Player.Interact.canceled += (val) => player.HandleInteract();

        action.Player.ViewTask.performed += (val) => player.HandleViewTask();

        action.Enable();
    }

    private void OnDisable()
    {
        action.Player.Move.performed -= (val) => player.HandleMove();
        action.Player.TurnRight.performed -= (val) => player.HandleRotate(90);
        action.Player.TurnLeft.performed -= (val) => player.HandleRotate(-90);

        action.Player.Kill.performed += (val) => player.HandleAttack();

        action.Player.Interact.performed += (val) => player.HandleInteract();
        action.Player.Interact.canceled += (val) => player.HandleInteract();

        action.Player.ViewTask.performed += (val) => player.HandleViewTask();


        action.Disable();
    }

}
