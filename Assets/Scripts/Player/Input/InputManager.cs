using UnityEngine;
using UnityEngine.InputSystem;

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
        if (player.controlScheme == "P0")
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
        else if (player.controlScheme == "P2")
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
            action.Player.TurnLeft.performed += (val) => player.HandleRotate(-90);

            action.Player4.InteractKill.performed += (val) => player.HandleInteract();
            action.Player4.InteractKill.canceled += (val) => player.HandleStopInteract();


            action.Player4.ViewTask.performed += (val) => player.HandleViewTask(true);
            action.Player4.ViewTask.canceled += (val) => player.HandleViewTask(false);
        }

        else
        {
            Invoke("WaitTimer", 0.1f);
        }

        action.Enable();
    }

    private void OnDisable()
    {
        action.Player.Move.performed -= (val) => player.HandleMove();
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
