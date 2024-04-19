//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/InputActions/AprilJamInputActions.inputactions
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

public partial class @AprilJamInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @AprilJamInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AprilJamInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cb9c15de-dbd2-4b91-91e9-f0a1cde8df82"",
            ""actions"": [
                {
                    ""name"": ""Do"",
                    ""type"": ""Button"",
                    ""id"": ""e837e8ff-45b5-44b0-a545-73aab9129705"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Re"",
                    ""type"": ""Button"",
                    ""id"": ""333d2a23-80ac-42da-852b-233ccf917391"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mi"",
                    ""type"": ""Button"",
                    ""id"": ""1499164a-6681-404e-a10e-0d175e733c74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fa"",
                    ""type"": ""Button"",
                    ""id"": ""3f822828-ce4b-4db5-8488-f5320838c2e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sol"",
                    ""type"": ""Button"",
                    ""id"": ""de9c17b2-dfbf-453e-a72e-4401816b92ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""La"",
                    ""type"": ""Button"",
                    ""id"": ""9524dddd-45c8-4109-9c4c-cc38d6d4b718"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Si"",
                    ""type"": ""Button"",
                    ""id"": ""269ee351-01d9-476a-98ab-208468b5b17b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""239cd527-fa99-4a5b-80ae-c1c7a94571eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Combination"",
                    ""type"": ""Button"",
                    ""id"": ""ee89da45-f6eb-4c2b-a1ff-5821fc89a740"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""723e3b8c-5aa9-4629-8968-367020c1ffa3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""084effe7-d071-462d-b3aa-fb029103d8be"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Do"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ee9b610-afdc-401d-bd59-0b03eeab3277"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Re"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5103f366-a2be-4f41-9412-5de34d5baf8a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mi"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""254b12ec-66db-4b5b-aecf-5622cb84f18c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcccd1e4-9caf-4f05-8bfc-afa694d86294"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2753e49-119b-4dbb-8c4a-0978d9c18201"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sol"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4120621d-98ea-4c46-99c5-f3d2538946e8"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""La"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db18bd2e-f47b-4c2d-aa24-3406a8f6d7ca"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""La"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3e56b1e-29d2-47d4-af12-2029690a0d4f"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Si"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abea4878-85a1-4397-bd1a-692e4f4926d8"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Si"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37066767-700a-4f2f-a52c-7eb361428453"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9c1422e-8635-43ec-b6ec-e727ced3b4d2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d74a01e-f8c5-4e80-93de-bb5ce4293f67"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combination"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30059159-9813-4cf7-9225-c356e191640a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""668df039-cecb-46a7-8b23-9997228ac6e8"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Value"",
                    ""id"": ""1a5baff3-5ef1-412d-8f9c-b04169a5fe7c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Apply"",
                    ""type"": ""Button"",
                    ""id"": ""2a6842bf-79bd-4741-a7b7-0a9124a9a1ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""7af241db-b9ff-4829-8a34-fbbd931759bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""2532d6f3-eaf7-47a4-a605-62ba3b847945"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""4332b590-262c-4e3c-90bd-96681d94e5a8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2a4824b-4e7e-46ed-ae4c-9f2e323093b1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""304f42f1-6d50-4d04-878a-4cdabd6b2b2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""25e3f173-71a0-41a6-8848-60485d3fd42f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bc4cfb6c-78c0-4aca-a9b7-218d9b57cb50"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""f674717d-2f57-4c4b-8dcc-ff046d8464f1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4719fff3-3992-4641-8f16-e3bbd65eb8e9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9bed24eb-a607-4114-8593-ed73958cba0f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e366bd61-a8b7-4b09-b6c4-9d397c7fd1b0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""84b13b94-b014-4188-b1ba-87556408aa85"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2b518a93-44b9-4f37-a0ee-131f48c16f2b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6eadc36-1592-4f6b-9476-7755b7a6d9fc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apply"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85569d36-6c63-4885-9df9-ee05476255a7"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e60acf6-bcd8-4216-ac85-7f2bde2e8546"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Do = m_Player.FindAction("Do", throwIfNotFound: true);
        m_Player_Re = m_Player.FindAction("Re", throwIfNotFound: true);
        m_Player_Mi = m_Player.FindAction("Mi", throwIfNotFound: true);
        m_Player_Fa = m_Player.FindAction("Fa", throwIfNotFound: true);
        m_Player_Sol = m_Player.FindAction("Sol", throwIfNotFound: true);
        m_Player_La = m_Player.FindAction("La", throwIfNotFound: true);
        m_Player_Si = m_Player.FindAction("Si", throwIfNotFound: true);
        m_Player_Confirm = m_Player.FindAction("Confirm", throwIfNotFound: true);
        m_Player_Combination = m_Player.FindAction("Combination", throwIfNotFound: true);
        m_Player_Menu = m_Player.FindAction("Menu", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Navigation = m_Menu.FindAction("Navigation", throwIfNotFound: true);
        m_Menu_Apply = m_Menu.FindAction("Apply", throwIfNotFound: true);
        m_Menu_Return = m_Menu.FindAction("Return", throwIfNotFound: true);
        m_Menu_Exit = m_Menu.FindAction("Exit", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Do;
    private readonly InputAction m_Player_Re;
    private readonly InputAction m_Player_Mi;
    private readonly InputAction m_Player_Fa;
    private readonly InputAction m_Player_Sol;
    private readonly InputAction m_Player_La;
    private readonly InputAction m_Player_Si;
    private readonly InputAction m_Player_Confirm;
    private readonly InputAction m_Player_Combination;
    private readonly InputAction m_Player_Menu;
    public struct PlayerActions
    {
        private @AprilJamInputActions m_Wrapper;
        public PlayerActions(@AprilJamInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Do => m_Wrapper.m_Player_Do;
        public InputAction @Re => m_Wrapper.m_Player_Re;
        public InputAction @Mi => m_Wrapper.m_Player_Mi;
        public InputAction @Fa => m_Wrapper.m_Player_Fa;
        public InputAction @Sol => m_Wrapper.m_Player_Sol;
        public InputAction @La => m_Wrapper.m_Player_La;
        public InputAction @Si => m_Wrapper.m_Player_Si;
        public InputAction @Confirm => m_Wrapper.m_Player_Confirm;
        public InputAction @Combination => m_Wrapper.m_Player_Combination;
        public InputAction @Menu => m_Wrapper.m_Player_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Do.started += instance.OnDo;
            @Do.performed += instance.OnDo;
            @Do.canceled += instance.OnDo;
            @Re.started += instance.OnRe;
            @Re.performed += instance.OnRe;
            @Re.canceled += instance.OnRe;
            @Mi.started += instance.OnMi;
            @Mi.performed += instance.OnMi;
            @Mi.canceled += instance.OnMi;
            @Fa.started += instance.OnFa;
            @Fa.performed += instance.OnFa;
            @Fa.canceled += instance.OnFa;
            @Sol.started += instance.OnSol;
            @Sol.performed += instance.OnSol;
            @Sol.canceled += instance.OnSol;
            @La.started += instance.OnLa;
            @La.performed += instance.OnLa;
            @La.canceled += instance.OnLa;
            @Si.started += instance.OnSi;
            @Si.performed += instance.OnSi;
            @Si.canceled += instance.OnSi;
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
            @Combination.started += instance.OnCombination;
            @Combination.performed += instance.OnCombination;
            @Combination.canceled += instance.OnCombination;
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Do.started -= instance.OnDo;
            @Do.performed -= instance.OnDo;
            @Do.canceled -= instance.OnDo;
            @Re.started -= instance.OnRe;
            @Re.performed -= instance.OnRe;
            @Re.canceled -= instance.OnRe;
            @Mi.started -= instance.OnMi;
            @Mi.performed -= instance.OnMi;
            @Mi.canceled -= instance.OnMi;
            @Fa.started -= instance.OnFa;
            @Fa.performed -= instance.OnFa;
            @Fa.canceled -= instance.OnFa;
            @Sol.started -= instance.OnSol;
            @Sol.performed -= instance.OnSol;
            @Sol.canceled -= instance.OnSol;
            @La.started -= instance.OnLa;
            @La.performed -= instance.OnLa;
            @La.canceled -= instance.OnLa;
            @Si.started -= instance.OnSi;
            @Si.performed -= instance.OnSi;
            @Si.canceled -= instance.OnSi;
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
            @Combination.started -= instance.OnCombination;
            @Combination.performed -= instance.OnCombination;
            @Combination.canceled -= instance.OnCombination;
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
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

    // Menu
    private readonly InputActionMap m_Menu;
    private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
    private readonly InputAction m_Menu_Navigation;
    private readonly InputAction m_Menu_Apply;
    private readonly InputAction m_Menu_Return;
    private readonly InputAction m_Menu_Exit;
    public struct MenuActions
    {
        private @AprilJamInputActions m_Wrapper;
        public MenuActions(@AprilJamInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigation => m_Wrapper.m_Menu_Navigation;
        public InputAction @Apply => m_Wrapper.m_Menu_Apply;
        public InputAction @Return => m_Wrapper.m_Menu_Return;
        public InputAction @Exit => m_Wrapper.m_Menu_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
            @Navigation.started += instance.OnNavigation;
            @Navigation.performed += instance.OnNavigation;
            @Navigation.canceled += instance.OnNavigation;
            @Apply.started += instance.OnApply;
            @Apply.performed += instance.OnApply;
            @Apply.canceled += instance.OnApply;
            @Return.started += instance.OnReturn;
            @Return.performed += instance.OnReturn;
            @Return.canceled += instance.OnReturn;
            @Exit.started += instance.OnExit;
            @Exit.performed += instance.OnExit;
            @Exit.canceled += instance.OnExit;
        }

        private void UnregisterCallbacks(IMenuActions instance)
        {
            @Navigation.started -= instance.OnNavigation;
            @Navigation.performed -= instance.OnNavigation;
            @Navigation.canceled -= instance.OnNavigation;
            @Apply.started -= instance.OnApply;
            @Apply.performed -= instance.OnApply;
            @Apply.canceled -= instance.OnApply;
            @Return.started -= instance.OnReturn;
            @Return.performed -= instance.OnReturn;
            @Return.canceled -= instance.OnReturn;
            @Exit.started -= instance.OnExit;
            @Exit.performed -= instance.OnExit;
            @Exit.canceled -= instance.OnExit;
        }

        public void RemoveCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IPlayerActions
    {
        void OnDo(InputAction.CallbackContext context);
        void OnRe(InputAction.CallbackContext context);
        void OnMi(InputAction.CallbackContext context);
        void OnFa(InputAction.CallbackContext context);
        void OnSol(InputAction.CallbackContext context);
        void OnLa(InputAction.CallbackContext context);
        void OnSi(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnCombination(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNavigation(InputAction.CallbackContext context);
        void OnApply(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}