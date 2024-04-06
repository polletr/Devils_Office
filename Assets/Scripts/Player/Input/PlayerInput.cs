//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Player/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""KeyboardLeft"",
            ""id"": ""0a5a1989-a98e-4bb0-8c37-e10b2bc86e89"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""bed8cffc-ff0f-4968-915a-e9c960c9cfc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""c1a09a7f-21d1-4abf-923a-fa03ecb2b872"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""ed34947f-9e33-41ed-982e-f04accbc0c21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InteractKill"",
                    ""type"": ""Button"",
                    ""id"": ""8c6f3110-71be-4fc3-9f8d-e8fb52153099"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ViewTask"",
                    ""type"": ""Button"",
                    ""id"": ""13e2db7d-9cb2-4c73-b780-a2a3d988fc16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""685b74ac-7a6d-4ab3-bfb1-434945b84127"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""242ddc7f-e33c-4530-8817-6af537b9cca1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16abbcd8-c54e-40df-aebb-d6b85b31f951"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbc22d65-6996-4d55-9e20-79486d75d625"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""240e61e5-09d0-426f-9703-f443bd6b440c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardRight"",
            ""id"": ""267293a6-c2fd-4da7-b683-31b1ba07e349"",
            ""actions"": [
                {
                    ""name"": ""ViewTask"",
                    ""type"": ""Button"",
                    ""id"": ""1f6738fe-bcc5-46d7-bb71-f8d5685a2ba3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InteractKill"",
                    ""type"": ""Button"",
                    ""id"": ""4acb560e-b7bb-4115-9bb4-12cc3a819e87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""ad794a30-4e1e-4e78-989b-cc8787e7677b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""54838cf7-944f-4ea1-9988-6fa9fad81ef8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""7ea96253-61f0-4fc8-97a5-d1262ad8941e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1825f0ad-10f4-4683-960e-efe2be6e1487"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfb7525a-0bb9-4f21-a671-1e96ce021b0c"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28f7d7c2-1e63-4ad7-8e4e-872044bd907c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ee8162e-287f-4606-a725-46b2d400355f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a4651a6-49fb-4aa8-91b6-cf2ff68cdb15"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""id"": ""9fc08146-8b67-4bd5-987d-cefa523bb1df"",
            ""actions"": [
                {
                    ""name"": ""ViewTask"",
                    ""type"": ""Button"",
                    ""id"": ""5470c5d2-2952-4118-a1ad-0e118f14d5ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InteractKill"",
                    ""type"": ""Button"",
                    ""id"": ""d86e540f-4390-466f-989b-cf6010a1721f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""a5b27a64-172b-47d9-9c83-bff38cc0cd62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ba676f94-468e-4ada-8c27-cb12b8bf27ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""5d1c9604-ae46-4f54-ade2-5c943420cf43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""119a9971-ad9f-4a27-a0e3-d728e8890aa7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d918d12d-f2e2-4025-bdc7-354ca9b1e8f1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c54020a7-fe4f-4e0f-b60f-a38d280a7330"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92ab2ce1-ce0d-4bb1-849b-1655a7fcde79"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81750083-d8fb-47f9-890c-de1a6f9275fa"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyboardLeft
        m_KeyboardLeft = asset.FindActionMap("KeyboardLeft", throwIfNotFound: true);
        m_KeyboardLeft_Move = m_KeyboardLeft.FindAction("Move", throwIfNotFound: true);
        m_KeyboardLeft_TurnLeft = m_KeyboardLeft.FindAction("TurnLeft", throwIfNotFound: true);
        m_KeyboardLeft_TurnRight = m_KeyboardLeft.FindAction("TurnRight", throwIfNotFound: true);
        m_KeyboardLeft_InteractKill = m_KeyboardLeft.FindAction("InteractKill", throwIfNotFound: true);
        m_KeyboardLeft_ViewTask = m_KeyboardLeft.FindAction("ViewTask", throwIfNotFound: true);
        // KeyboardRight
        m_KeyboardRight = asset.FindActionMap("KeyboardRight", throwIfNotFound: true);
        m_KeyboardRight_ViewTask = m_KeyboardRight.FindAction("ViewTask", throwIfNotFound: true);
        m_KeyboardRight_InteractKill = m_KeyboardRight.FindAction("InteractKill", throwIfNotFound: true);
        m_KeyboardRight_TurnRight = m_KeyboardRight.FindAction("TurnRight", throwIfNotFound: true);
        m_KeyboardRight_TurnLeft = m_KeyboardRight.FindAction("TurnLeft", throwIfNotFound: true);
        m_KeyboardRight_Move = m_KeyboardRight.FindAction("Move", throwIfNotFound: true);
        // GamePad
        m_GamePad = asset.FindActionMap("GamePad", throwIfNotFound: true);
        m_GamePad_ViewTask = m_GamePad.FindAction("ViewTask", throwIfNotFound: true);
        m_GamePad_InteractKill = m_GamePad.FindAction("InteractKill", throwIfNotFound: true);
        m_GamePad_TurnRight = m_GamePad.FindAction("TurnRight", throwIfNotFound: true);
        m_GamePad_TurnLeft = m_GamePad.FindAction("TurnLeft", throwIfNotFound: true);
        m_GamePad_Move = m_GamePad.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // KeyboardLeft
    private readonly InputActionMap m_KeyboardLeft;
    private List<IKeyboardLeftActions> m_KeyboardLeftActionsCallbackInterfaces = new List<IKeyboardLeftActions>();
    private readonly InputAction m_KeyboardLeft_Move;
    private readonly InputAction m_KeyboardLeft_TurnLeft;
    private readonly InputAction m_KeyboardLeft_TurnRight;
    private readonly InputAction m_KeyboardLeft_InteractKill;
    private readonly InputAction m_KeyboardLeft_ViewTask;
    public struct KeyboardLeftActions
    {
        private @PlayerInput m_Wrapper;
        public KeyboardLeftActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_KeyboardLeft_Move;
        public InputAction @TurnLeft => m_Wrapper.m_KeyboardLeft_TurnLeft;
        public InputAction @TurnRight => m_Wrapper.m_KeyboardLeft_TurnRight;
        public InputAction @InteractKill => m_Wrapper.m_KeyboardLeft_InteractKill;
        public InputAction @ViewTask => m_Wrapper.m_KeyboardLeft_ViewTask;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardLeft; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardLeftActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardLeftActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardLeftActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardLeftActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @TurnLeft.started += instance.OnTurnLeft;
            @TurnLeft.performed += instance.OnTurnLeft;
            @TurnLeft.canceled += instance.OnTurnLeft;
            @TurnRight.started += instance.OnTurnRight;
            @TurnRight.performed += instance.OnTurnRight;
            @TurnRight.canceled += instance.OnTurnRight;
            @InteractKill.started += instance.OnInteractKill;
            @InteractKill.performed += instance.OnInteractKill;
            @InteractKill.canceled += instance.OnInteractKill;
            @ViewTask.started += instance.OnViewTask;
            @ViewTask.performed += instance.OnViewTask;
            @ViewTask.canceled += instance.OnViewTask;
        }

        private void UnregisterCallbacks(IKeyboardLeftActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @TurnLeft.started -= instance.OnTurnLeft;
            @TurnLeft.performed -= instance.OnTurnLeft;
            @TurnLeft.canceled -= instance.OnTurnLeft;
            @TurnRight.started -= instance.OnTurnRight;
            @TurnRight.performed -= instance.OnTurnRight;
            @TurnRight.canceled -= instance.OnTurnRight;
            @InteractKill.started -= instance.OnInteractKill;
            @InteractKill.performed -= instance.OnInteractKill;
            @InteractKill.canceled -= instance.OnInteractKill;
            @ViewTask.started -= instance.OnViewTask;
            @ViewTask.performed -= instance.OnViewTask;
            @ViewTask.canceled -= instance.OnViewTask;
        }

        public void RemoveCallbacks(IKeyboardLeftActions instance)
        {
            if (m_Wrapper.m_KeyboardLeftActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardLeftActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardLeftActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardLeftActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardLeftActions @KeyboardLeft => new KeyboardLeftActions(this);

    // KeyboardRight
    private readonly InputActionMap m_KeyboardRight;
    private List<IKeyboardRightActions> m_KeyboardRightActionsCallbackInterfaces = new List<IKeyboardRightActions>();
    private readonly InputAction m_KeyboardRight_ViewTask;
    private readonly InputAction m_KeyboardRight_InteractKill;
    private readonly InputAction m_KeyboardRight_TurnRight;
    private readonly InputAction m_KeyboardRight_TurnLeft;
    private readonly InputAction m_KeyboardRight_Move;
    public struct KeyboardRightActions
    {
        private @PlayerInput m_Wrapper;
        public KeyboardRightActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ViewTask => m_Wrapper.m_KeyboardRight_ViewTask;
        public InputAction @InteractKill => m_Wrapper.m_KeyboardRight_InteractKill;
        public InputAction @TurnRight => m_Wrapper.m_KeyboardRight_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_KeyboardRight_TurnLeft;
        public InputAction @Move => m_Wrapper.m_KeyboardRight_Move;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardRight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardRightActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardRightActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardRightActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardRightActionsCallbackInterfaces.Add(instance);
            @ViewTask.started += instance.OnViewTask;
            @ViewTask.performed += instance.OnViewTask;
            @ViewTask.canceled += instance.OnViewTask;
            @InteractKill.started += instance.OnInteractKill;
            @InteractKill.performed += instance.OnInteractKill;
            @InteractKill.canceled += instance.OnInteractKill;
            @TurnRight.started += instance.OnTurnRight;
            @TurnRight.performed += instance.OnTurnRight;
            @TurnRight.canceled += instance.OnTurnRight;
            @TurnLeft.started += instance.OnTurnLeft;
            @TurnLeft.performed += instance.OnTurnLeft;
            @TurnLeft.canceled += instance.OnTurnLeft;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IKeyboardRightActions instance)
        {
            @ViewTask.started -= instance.OnViewTask;
            @ViewTask.performed -= instance.OnViewTask;
            @ViewTask.canceled -= instance.OnViewTask;
            @InteractKill.started -= instance.OnInteractKill;
            @InteractKill.performed -= instance.OnInteractKill;
            @InteractKill.canceled -= instance.OnInteractKill;
            @TurnRight.started -= instance.OnTurnRight;
            @TurnRight.performed -= instance.OnTurnRight;
            @TurnRight.canceled -= instance.OnTurnRight;
            @TurnLeft.started -= instance.OnTurnLeft;
            @TurnLeft.performed -= instance.OnTurnLeft;
            @TurnLeft.canceled -= instance.OnTurnLeft;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IKeyboardRightActions instance)
        {
            if (m_Wrapper.m_KeyboardRightActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardRightActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardRightActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardRightActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardRightActions @KeyboardRight => new KeyboardRightActions(this);

    // GamePad
    private readonly InputActionMap m_GamePad;
    private List<IGamePadActions> m_GamePadActionsCallbackInterfaces = new List<IGamePadActions>();
    private readonly InputAction m_GamePad_ViewTask;
    private readonly InputAction m_GamePad_InteractKill;
    private readonly InputAction m_GamePad_TurnRight;
    private readonly InputAction m_GamePad_TurnLeft;
    private readonly InputAction m_GamePad_Move;
    public struct GamePadActions
    {
        private @PlayerInput m_Wrapper;
        public GamePadActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ViewTask => m_Wrapper.m_GamePad_ViewTask;
        public InputAction @InteractKill => m_Wrapper.m_GamePad_InteractKill;
        public InputAction @TurnRight => m_Wrapper.m_GamePad_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_GamePad_TurnLeft;
        public InputAction @Move => m_Wrapper.m_GamePad_Move;
        public InputActionMap Get() { return m_Wrapper.m_GamePad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePadActions set) { return set.Get(); }
        public void AddCallbacks(IGamePadActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePadActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePadActionsCallbackInterfaces.Add(instance);
            @ViewTask.started += instance.OnViewTask;
            @ViewTask.performed += instance.OnViewTask;
            @ViewTask.canceled += instance.OnViewTask;
            @InteractKill.started += instance.OnInteractKill;
            @InteractKill.performed += instance.OnInteractKill;
            @InteractKill.canceled += instance.OnInteractKill;
            @TurnRight.started += instance.OnTurnRight;
            @TurnRight.performed += instance.OnTurnRight;
            @TurnRight.canceled += instance.OnTurnRight;
            @TurnLeft.started += instance.OnTurnLeft;
            @TurnLeft.performed += instance.OnTurnLeft;
            @TurnLeft.canceled += instance.OnTurnLeft;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IGamePadActions instance)
        {
            @ViewTask.started -= instance.OnViewTask;
            @ViewTask.performed -= instance.OnViewTask;
            @ViewTask.canceled -= instance.OnViewTask;
            @InteractKill.started -= instance.OnInteractKill;
            @InteractKill.performed -= instance.OnInteractKill;
            @InteractKill.canceled -= instance.OnInteractKill;
            @TurnRight.started -= instance.OnTurnRight;
            @TurnRight.performed -= instance.OnTurnRight;
            @TurnRight.canceled -= instance.OnTurnRight;
            @TurnLeft.started -= instance.OnTurnLeft;
            @TurnLeft.performed -= instance.OnTurnLeft;
            @TurnLeft.canceled -= instance.OnTurnLeft;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IGamePadActions instance)
        {
            if (m_Wrapper.m_GamePadActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePadActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePadActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePadActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePadActions @GamePad => new GamePadActions(this);
    public interface IKeyboardLeftActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnViewTask(InputAction.CallbackContext context);
    }
    public interface IKeyboardRightActions
    {
        void OnViewTask(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IGamePadActions
    {
        void OnViewTask(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
