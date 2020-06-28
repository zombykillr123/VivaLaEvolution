// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""7b7676ac-b306-474c-9231-e3bee57cf3eb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25e1c827-2dff-4358-9eff-cda37dfefd0e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""f4d34397-3702-4c43-90b0-2c575bd9200f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""eca1a688-2d9c-4db0-9c11-6770dcd43b1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""c7b0e3ae-20d7-4d08-8577-123a3aa016bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""e3001a64-cb0f-45a2-8647-cbb86dacc3a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Evolve"",
                    ""type"": ""Button"",
                    ""id"": ""7bb6ca7e-c38d-43b3-9858-28f0ce78ec07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0a8a706b-c52d-490c-b047-0ee64ebc71ab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""85488464-2e24-4503-b319-584ff120536c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b3b3d36a-ad0b-4a7f-8bc0-7dd2cc6d555b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""af57b9c6-583c-4d9b-b691-61562ca738c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""88629daf-cad3-4049-ba30-8e8cf24b4333"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""55394135-746b-4d01-8651-c14df801cad7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce29a531-975f-4b04-92ad-43f5aa7a3116"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""715724c3-e8ea-4352-9a3d-c03a6bd15832"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4011f5b1-ab5a-477a-8a6d-cefccb1ba5a9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59025e8b-524a-480e-8710-7168cd5503a3"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Evolve"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""834ecb8a-9a5f-4733-978f-d3083d456953"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""467f47d8-5a10-4c7e-8dd4-876827dd652d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""04991295-5b06-439b-92aa-1c612e762bdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""9d3c8684-1232-4dd5-8f99-53d7b4c4625e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""f43a3cc6-3ce8-4f0d-8479-612c42ef37b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""f41cdedf-29d6-4edb-801a-85ba96704a38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow"",
                    ""id"": ""8658e455-5ff2-4b9a-a7a8-a69aae1c7765"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21170b6d-97ae-4712-8f51-f179fa343948"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""60247789-b41e-4b0d-9eff-7f1d0b35a7e6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6533210b-786c-49e1-ae11-958ead9a14c0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3f50a11f-70af-41ca-89f4-43058aea39ef"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""36657a7a-d75d-4fdd-978b-a2884f09bf92"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48fbca8e-b4ed-4b36-aa7a-c748f9447659"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d81db69-649f-4d1a-9c0b-e553e6043c05"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""825eaeb0-944c-4370-9779-9f67f56fdb56"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76b3b7d2-656d-4062-b229-312cfef69167"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8b406fe-6316-4f45-be62-b3b88f26a877"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Move = m_Player1.FindAction("Move", throwIfNotFound: true);
        m_Player1_Ability1 = m_Player1.FindAction("Ability1", throwIfNotFound: true);
        m_Player1_Ability2 = m_Player1.FindAction("Ability2", throwIfNotFound: true);
        m_Player1_Ability3 = m_Player1.FindAction("Ability3", throwIfNotFound: true);
        m_Player1_Ability4 = m_Player1.FindAction("Ability4", throwIfNotFound: true);
        m_Player1_Evolve = m_Player1.FindAction("Evolve", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Move = m_Player2.FindAction("Move", throwIfNotFound: true);
        m_Player2_Ability1 = m_Player2.FindAction("Ability1", throwIfNotFound: true);
        m_Player2_Ability2 = m_Player2.FindAction("Ability2", throwIfNotFound: true);
        m_Player2_Ability3 = m_Player2.FindAction("Ability3", throwIfNotFound: true);
        m_Player2_Ability4 = m_Player2.FindAction("Ability4", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_Ability1;
    private readonly InputAction m_Player1_Ability2;
    private readonly InputAction m_Player1_Ability3;
    private readonly InputAction m_Player1_Ability4;
    private readonly InputAction m_Player1_Evolve;
    public struct Player1Actions
    {
        private @PlayerControls m_Wrapper;
        public Player1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @Ability1 => m_Wrapper.m_Player1_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Player1_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_Player1_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_Player1_Ability4;
        public InputAction @Evolve => m_Wrapper.m_Player1_Evolve;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Ability1.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility1;
                @Ability2.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility2;
                @Ability3.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility3;
                @Ability3.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility3;
                @Ability3.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility3;
                @Ability4.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility4;
                @Ability4.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility4;
                @Ability4.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbility4;
                @Evolve.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnEvolve;
                @Evolve.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnEvolve;
                @Evolve.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnEvolve;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
                @Ability3.started += instance.OnAbility3;
                @Ability3.performed += instance.OnAbility3;
                @Ability3.canceled += instance.OnAbility3;
                @Ability4.started += instance.OnAbility4;
                @Ability4.performed += instance.OnAbility4;
                @Ability4.canceled += instance.OnAbility4;
                @Evolve.started += instance.OnEvolve;
                @Evolve.performed += instance.OnEvolve;
                @Evolve.canceled += instance.OnEvolve;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Move;
    private readonly InputAction m_Player2_Ability1;
    private readonly InputAction m_Player2_Ability2;
    private readonly InputAction m_Player2_Ability3;
    private readonly InputAction m_Player2_Ability4;
    public struct Player2Actions
    {
        private @PlayerControls m_Wrapper;
        public Player2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputAction @Ability1 => m_Wrapper.m_Player2_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Player2_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_Player2_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_Player2_Ability4;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Ability1.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility1;
                @Ability2.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility2;
                @Ability3.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility3;
                @Ability3.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility3;
                @Ability3.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility3;
                @Ability4.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility4;
                @Ability4.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility4;
                @Ability4.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAbility4;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
                @Ability3.started += instance.OnAbility3;
                @Ability3.performed += instance.OnAbility3;
                @Ability3.canceled += instance.OnAbility3;
                @Ability4.started += instance.OnAbility4;
                @Ability4.performed += instance.OnAbility4;
                @Ability4.canceled += instance.OnAbility4;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    public interface IPlayer1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
        void OnEvolve(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
    }
}
