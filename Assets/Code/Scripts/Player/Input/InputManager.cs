using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInput action;
    PlayerController player;
    Vector2 _movement;
    public Vector2 Movement
    {
        get
        {
            return _movement;
        }
        private set
        {
            _movement = value;
        }
    }

    void Awake()
    {
        //player = GetComponent<PlayerContoller>();
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

        action.Player.Move.performed += (val) => Movement = player.HandleMovement();
        action.Player.TurnRight.performed += (val) => Movement = new Vector2(1, 0);
        action.Player.TurnLeft.performed += (val) => Movement = new Vector2(-1, 0);

/*        action.Player.Kill.performed += (val) => player.HandleKill();

        action.Player.Interact.performed += (val) => player.HandleInteract();
        action.Player.Interact.canceled += (val) => player.HandleInteract();

        action.Player.ViewTask.performed += (val) => player.HandleViewTask();
*/
        action.Enable();
    }

    private void OnDisable()
    {

        action.Disable();
    }

}
