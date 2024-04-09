using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    PlayerInput action;
    PlayerController player { get; set; }
    Vector2 _rotate;
    [SerializeField]
    public InputDevice playerDevice;
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

        action = new PlayerInput();
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
       
        //var device = InputAction.CallbackContext.control.device;

        if (playerDevice is Keyboard)
        {
            var keyboardLeft = action.KeyboardLeft;
            keyboardLeft.Move.performed += ctx => HandleAction(ctx, player.HandleMove, true);
            keyboardLeft.Move.canceled += ctx => HandleAction(ctx, player.HandleMove, false);
            keyboardLeft.TurnRight.performed += ctx => HandleRotate(ctx, player.HandleRotate, 90f);
            keyboardLeft.TurnLeft.performed += ctx => HandleRotate(ctx, player.HandleRotate, -90f);
            keyboardLeft.InteractKill.performed += ctx => HandleAction2(ctx, player.HandleInteract);
            keyboardLeft.InteractKill.canceled += ctx => HandleAction2(ctx, player.HandleStopInteract);
            keyboardLeft.ViewTask.performed += ctx => HandleAction(ctx, player.HandleViewTask, true);
            keyboardLeft.ViewTask.canceled += ctx => HandleAction(ctx, player.HandleViewTask, false);
        }
        else if (playerDevice is Keyboard)
        {
            var keyboardRight = action.KeyboardRight;
            keyboardRight.Move.performed += ctx => HandleAction(ctx, player.HandleMove, true);
            keyboardRight.Move.canceled += ctx => HandleAction(ctx, player.HandleMove, false);
            keyboardRight.TurnRight.performed += ctx => HandleRotate(ctx, player.HandleRotate, 90f);
            keyboardRight.TurnLeft.performed += ctx => HandleRotate(ctx, player.HandleRotate, -90f);
            keyboardRight.InteractKill.performed += ctx => HandleAction2(ctx, player.HandleInteract);
            keyboardRight.InteractKill.canceled += ctx => HandleAction2(ctx, player.HandleStopInteract);
            keyboardRight.ViewTask.performed += ctx => HandleAction(ctx, player.HandleViewTask, true);
            keyboardRight.ViewTask.canceled += ctx => HandleAction(ctx, player.HandleViewTask, false);
        }
        else if (playerDevice is Gamepad)
        {
            var gamePad = action.GamePad;
            gamePad.Move.performed += ctx => HandleAction(ctx, player.HandleMove, true);
            gamePad.Move.canceled += ctx => HandleAction(ctx, player.HandleMove, false);
            gamePad.TurnRight.performed += ctx => HandleRotate(ctx, player.HandleRotate, 90f);
            gamePad.TurnLeft.performed += ctx => HandleRotate(ctx, player.HandleRotate, -90f);
            gamePad.InteractKill.performed += ctx => HandleAction2(ctx, player.HandleInteract);
            gamePad.InteractKill.canceled += ctx => HandleAction2(ctx, player.HandleStopInteract);
            gamePad.ViewTask.performed += ctx => HandleAction(ctx, player.HandleViewTask, true);
            gamePad.ViewTask.canceled += ctx => HandleAction(ctx, player.HandleViewTask, false);
        }
    }

    private void HandleAction(InputAction.CallbackContext ctx, Action<bool> action, bool state)
    {
        if (ctx.control.device == playerDevice)
            action(state);
    }
    private void HandleAction2(InputAction.CallbackContext ctx, Action action)
    {
        if (ctx.control.device == playerDevice)
            action();
    }

    private void HandleRotate(InputAction.CallbackContext ctx, Action<float> action, float degree)
    {
        if (ctx.control.device == playerDevice)
        {
            Debug.Log(ctx.control.device);
            action(degree);
        }
    }



    private void ConnectControls(PlayerInput p)
    {

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
