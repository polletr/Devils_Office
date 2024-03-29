//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Code/Scripts/Player/Input/PlayerInput.inputactions
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
            ""name"": ""Player"",
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
                    ""id"": ""2283ad0a-7280-4072-8935-e7eff1fe1c7f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P0"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abddaf06-9990-48d3-81ad-d8f9a2359e6c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P0"",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9860433-4165-4844-ae10-4d9394e88c20"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P0"",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ded08dad-dc9e-42b6-9627-840ccc314f66"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P0"",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1b25ac3-3985-4d77-bcdc-3693435813aa"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P0"",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
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
                    ""id"": ""70dde6b7-07b4-4f10-afe3-1584c8e98489"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8848c71f-ea1b-41b6-b878-366ba2710f8d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c185f94-1e80-443b-b16e-6e4825bbe2ca"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""911ada2e-2f97-449a-b7b5-083bd841f89f"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efe784f0-de80-424a-8189-b6807a5e6389"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player3"",
            ""id"": ""b5c5b5a8-3a58-4607-bf8d-6eee85f235c7"",
            ""actions"": [
                {
                    ""name"": ""ViewTask"",
                    ""type"": ""Button"",
                    ""id"": ""31501137-cabc-4192-badf-40d3781d30a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InteractKill"",
                    ""type"": ""Button"",
                    ""id"": ""60ac813e-300a-4eb8-9974-cf1c33e82b7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""90906ebd-ff57-4f47-83fb-158adf2c6046"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5919a8d2-9511-4e14-a95a-8a7f1090b442"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e7fb0774-e199-48c4-b734-e138c64fa913"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0fd57d5-aab1-434d-9818-b937af003dec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cc62e1d-7430-4a8d-a44b-17895b98b132"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""914fb91a-a9e4-4d7c-8c3f-469d29eb428f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37ca3deb-0c79-4181-b1e5-81b213ed973f"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a5d10ab-963f-4ad8-8a7d-e4f54611c953"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player4"",
            ""id"": ""3c299eae-eabd-45d0-aa2d-a8f5f7b24fd1"",
            ""actions"": [
                {
                    ""name"": ""ViewTask"",
                    ""type"": ""Button"",
                    ""id"": ""a5ef94f1-b139-4f04-8e2f-790c666a2f72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InteractKill"",
                    ""type"": ""Button"",
                    ""id"": ""f2edb428-41e8-4d4d-9857-b23444df4c08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""15a6fd36-1b38-4b7f-87b8-959f127388c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""78118871-9896-4c00-820a-1dcee1e44b7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c2985d9f-3d90-435d-a008-9f5e96ad77f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b4fbac07-0c07-4e3c-96e2-65421a95d51a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99e47f21-82e7-4bf7-a535-88244d996317"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c4e92f8-6b6a-418a-b909-37b2e1f25ed2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60ff7320-d463-4d2f-a86d-05b0c84bf54d"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""InteractKill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb47637b-f4b4-4b85-863c-909e74fffe91"",
                    ""path"": ""<Keyboard>/backslash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""P1"",
                    ""action"": ""ViewTask"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""P0"",
            ""bindingGroup"": ""P0"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""P1"",
            ""bindingGroup"": ""P1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_TurnLeft = m_Player.FindAction("TurnLeft", throwIfNotFound: true);
        m_Player_TurnRight = m_Player.FindAction("TurnRight", throwIfNotFound: true);
        m_Player_InteractKill = m_Player.FindAction("InteractKill", throwIfNotFound: true);
        m_Player_ViewTask = m_Player.FindAction("ViewTask", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_ViewTask = m_Player2.FindAction("ViewTask", throwIfNotFound: true);
        m_Player2_InteractKill = m_Player2.FindAction("InteractKill", throwIfNotFound: true);
        m_Player2_TurnRight = m_Player2.FindAction("TurnRight", throwIfNotFound: true);
        m_Player2_TurnLeft = m_Player2.FindAction("TurnLeft", throwIfNotFound: true);
        m_Player2_Move = m_Player2.FindAction("Move", throwIfNotFound: true);
        // Player3
        m_Player3 = asset.FindActionMap("Player3", throwIfNotFound: true);
        m_Player3_ViewTask = m_Player3.FindAction("ViewTask", throwIfNotFound: true);
        m_Player3_InteractKill = m_Player3.FindAction("InteractKill", throwIfNotFound: true);
        m_Player3_TurnRight = m_Player3.FindAction("TurnRight", throwIfNotFound: true);
        m_Player3_TurnLeft = m_Player3.FindAction("TurnLeft", throwIfNotFound: true);
        m_Player3_Move = m_Player3.FindAction("Move", throwIfNotFound: true);
        // Player4
        m_Player4 = asset.FindActionMap("Player4", throwIfNotFound: true);
        m_Player4_ViewTask = m_Player4.FindAction("ViewTask", throwIfNotFound: true);
        m_Player4_InteractKill = m_Player4.FindAction("InteractKill", throwIfNotFound: true);
        m_Player4_TurnRight = m_Player4.FindAction("TurnRight", throwIfNotFound: true);
        m_Player4_TurnLeft = m_Player4.FindAction("TurnLeft", throwIfNotFound: true);
        m_Player4_Move = m_Player4.FindAction("Move", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_TurnLeft;
    private readonly InputAction m_Player_TurnRight;
    private readonly InputAction m_Player_InteractKill;
    private readonly InputAction m_Player_ViewTask;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @TurnLeft => m_Wrapper.m_Player_TurnLeft;
        public InputAction @TurnRight => m_Wrapper.m_Player_TurnRight;
        public InputAction @InteractKill => m_Wrapper.m_Player_InteractKill;
        public InputAction @ViewTask => m_Wrapper.m_Player_ViewTask;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
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

        private void UnregisterCallbacks(IPlayerActions instance)
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

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private List<IPlayer2Actions> m_Player2ActionsCallbackInterfaces = new List<IPlayer2Actions>();
    private readonly InputAction m_Player2_ViewTask;
    private readonly InputAction m_Player2_InteractKill;
    private readonly InputAction m_Player2_TurnRight;
    private readonly InputAction m_Player2_TurnLeft;
    private readonly InputAction m_Player2_Move;
    public struct Player2Actions
    {
        private @PlayerInput m_Wrapper;
        public Player2Actions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ViewTask => m_Wrapper.m_Player2_ViewTask;
        public InputAction @InteractKill => m_Wrapper.m_Player2_InteractKill;
        public InputAction @TurnRight => m_Wrapper.m_Player2_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_Player2_TurnLeft;
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer2Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player2ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Add(instance);
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

        private void UnregisterCallbacks(IPlayer2Actions instance)
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

        public void RemoveCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer2Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player2ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // Player3
    private readonly InputActionMap m_Player3;
    private List<IPlayer3Actions> m_Player3ActionsCallbackInterfaces = new List<IPlayer3Actions>();
    private readonly InputAction m_Player3_ViewTask;
    private readonly InputAction m_Player3_InteractKill;
    private readonly InputAction m_Player3_TurnRight;
    private readonly InputAction m_Player3_TurnLeft;
    private readonly InputAction m_Player3_Move;
    public struct Player3Actions
    {
        private @PlayerInput m_Wrapper;
        public Player3Actions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ViewTask => m_Wrapper.m_Player3_ViewTask;
        public InputAction @InteractKill => m_Wrapper.m_Player3_InteractKill;
        public InputAction @TurnRight => m_Wrapper.m_Player3_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_Player3_TurnLeft;
        public InputAction @Move => m_Wrapper.m_Player3_Move;
        public InputActionMap Get() { return m_Wrapper.m_Player3; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player3Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer3Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player3ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player3ActionsCallbackInterfaces.Add(instance);
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

        private void UnregisterCallbacks(IPlayer3Actions instance)
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

        public void RemoveCallbacks(IPlayer3Actions instance)
        {
            if (m_Wrapper.m_Player3ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer3Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player3ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player3ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player3Actions @Player3 => new Player3Actions(this);

    // Player4
    private readonly InputActionMap m_Player4;
    private List<IPlayer4Actions> m_Player4ActionsCallbackInterfaces = new List<IPlayer4Actions>();
    private readonly InputAction m_Player4_ViewTask;
    private readonly InputAction m_Player4_InteractKill;
    private readonly InputAction m_Player4_TurnRight;
    private readonly InputAction m_Player4_TurnLeft;
    private readonly InputAction m_Player4_Move;
    public struct Player4Actions
    {
        private @PlayerInput m_Wrapper;
        public Player4Actions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ViewTask => m_Wrapper.m_Player4_ViewTask;
        public InputAction @InteractKill => m_Wrapper.m_Player4_InteractKill;
        public InputAction @TurnRight => m_Wrapper.m_Player4_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_Player4_TurnLeft;
        public InputAction @Move => m_Wrapper.m_Player4_Move;
        public InputActionMap Get() { return m_Wrapper.m_Player4; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player4Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer4Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player4ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player4ActionsCallbackInterfaces.Add(instance);
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

        private void UnregisterCallbacks(IPlayer4Actions instance)
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

        public void RemoveCallbacks(IPlayer4Actions instance)
        {
            if (m_Wrapper.m_Player4ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer4Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player4ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player4ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player4Actions @Player4 => new Player4Actions(this);
    private int m_P0SchemeIndex = -1;
    public InputControlScheme P0Scheme
    {
        get
        {
            if (m_P0SchemeIndex == -1) m_P0SchemeIndex = asset.FindControlSchemeIndex("P0");
            return asset.controlSchemes[m_P0SchemeIndex];
        }
    }
    private int m_P1SchemeIndex = -1;
    public InputControlScheme P1Scheme
    {
        get
        {
            if (m_P1SchemeIndex == -1) m_P1SchemeIndex = asset.FindControlSchemeIndex("P1");
            return asset.controlSchemes[m_P1SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnViewTask(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnViewTask(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IPlayer3Actions
    {
        void OnViewTask(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IPlayer4Actions
    {
        void OnViewTask(InputAction.CallbackContext context);
        void OnInteractKill(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
