//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.0
//     from Assets/Settings/GameControls.inputactions
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
using UnityEngine;

public partial class @GameControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""51a105cd-134c-40ad-af3a-55e86f6bed48"",
            ""actions"": [
                {
                    ""name"": ""Close Menu"",
                    ""type"": ""Button"",
                    ""id"": ""097370a2-36a4-4a23-bfe8-65f9e7a62ce6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3dc86978-f071-4a16-9db4-bbb295c82dec"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""42cb9a7d-af2b-4ee6-8f13-999f33097ed5"",
            ""actions"": [
                {
                    ""name"": ""Upgrade"",
                    ""type"": ""Button"",
                    ""id"": ""89ab53a3-b845-4c06-931d-a8d58d372c74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Add Battery"",
                    ""type"": ""Button"",
                    ""id"": ""04f7991b-50ab-4dc4-8fbd-0f535967a905"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape To Menu"",
                    ""type"": ""Button"",
                    ""id"": ""79084552-0a3c-4162-a177-99520d8a6d2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Eating"",
                    ""type"": ""Button"",
                    ""id"": ""ec69fcf6-c65a-4913-9720-d786e7fca565"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Flashlight"",
                    ""type"": ""Button"",
                    ""id"": ""d71db477-be92-4cd3-be18-2e5e1f2c665a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Walking"",
                    ""type"": ""Button"",
                    ""id"": ""dd139e1a-f645-418a-a763-acb50d7215c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Remove Battery"",
                    ""type"": ""Button"",
                    ""id"": ""c5e25ff7-a4f3-4b75-8c4a-65708c1127db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Activate Hive"",
                    ""type"": ""Button"",
                    ""id"": ""4cd94c66-e221-4378-94e1-4cad21ed56c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d12587b6-0635-4b4a-a174-fa333eff8e77"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Upgrade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f48d0b3-39e5-4834-a120-1eee1b7997e6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Add Battery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab291bd4-9f0d-44da-a691-1276ce520eba"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape To Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ae69821-f000-438e-9b80-7722d552d42d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Eating"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5baeb002-f153-4453-9209-b38ed38be492"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4261474-0270-40ac-8fd5-69b159af5834"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71f1b2fc-a975-45e5-8787-a9e1c8bdfc46"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04862570-9b93-4298-8582-783ff709f4d9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f826f091-84d9-4be6-9d77-8fea96b6b4e6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71451105-8f4c-47f5-b77f-9bbbfe9c756a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Remove Battery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dc28483-a818-4c68-a443-84ef02a53778"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate Hive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Upgrade"",
            ""id"": ""5ca97cbc-c74d-42ac-abcd-19a468211f90"",
            ""actions"": [
                {
                    ""name"": ""Close Menu"",
                    ""type"": ""Button"",
                    ""id"": ""a464c86c-3067-4064-abf2-dbcfb1b9f118"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d0ad54c-aead-4496-8db7-f2873b80fdd9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_CloseMenu = m_Menu.FindAction("Close Menu", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Upgrade = m_Player.FindAction("Upgrade", throwIfNotFound: true);
        m_Player_AddBattery = m_Player.FindAction("Add Battery", throwIfNotFound: true);
        m_Player_EscapeToMenu = m_Player.FindAction("Escape To Menu", throwIfNotFound: true);
        m_Player_Eating = m_Player.FindAction("Eating", throwIfNotFound: true);
        m_Player_Flashlight = m_Player.FindAction("Flashlight", throwIfNotFound: true);
        m_Player_Walking = m_Player.FindAction("Walking", throwIfNotFound: true);
        m_Player_RemoveBattery = m_Player.FindAction("Remove Battery", throwIfNotFound: true);
        m_Player_ActivateHive = m_Player.FindAction("Activate Hive", throwIfNotFound: true);
        // Upgrade
        m_Upgrade = asset.FindActionMap("Upgrade", throwIfNotFound: true);
        m_Upgrade_CloseMenu = m_Upgrade.FindAction("Close Menu", throwIfNotFound: true);
    }

    ~@GameControls()
    {
        Debug.Assert(!m_Menu.enabled, "This will cause a leak and performance issues, GameControls.Menu.Disable() has not been called.");
        Debug.Assert(!m_Player.enabled, "This will cause a leak and performance issues, GameControls.Player.Disable() has not been called.");
        Debug.Assert(!m_Upgrade.enabled, "This will cause a leak and performance issues, GameControls.Upgrade.Disable() has not been called.");
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

    // Menu
    private readonly InputActionMap m_Menu;
    private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
    private readonly InputAction m_Menu_CloseMenu;
    public struct MenuActions
    {
        private @GameControls m_Wrapper;
        public MenuActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseMenu => m_Wrapper.m_Menu_CloseMenu;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
            @CloseMenu.started += instance.OnCloseMenu;
            @CloseMenu.performed += instance.OnCloseMenu;
            @CloseMenu.canceled += instance.OnCloseMenu;
        }

        private void UnregisterCallbacks(IMenuActions instance)
        {
            @CloseMenu.started -= instance.OnCloseMenu;
            @CloseMenu.performed -= instance.OnCloseMenu;
            @CloseMenu.canceled -= instance.OnCloseMenu;
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Upgrade;
    private readonly InputAction m_Player_AddBattery;
    private readonly InputAction m_Player_EscapeToMenu;
    private readonly InputAction m_Player_Eating;
    private readonly InputAction m_Player_Flashlight;
    private readonly InputAction m_Player_Walking;
    private readonly InputAction m_Player_RemoveBattery;
    private readonly InputAction m_Player_ActivateHive;
    public struct PlayerActions
    {
        private @GameControls m_Wrapper;
        public PlayerActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Upgrade => m_Wrapper.m_Player_Upgrade;
        public InputAction @AddBattery => m_Wrapper.m_Player_AddBattery;
        public InputAction @EscapeToMenu => m_Wrapper.m_Player_EscapeToMenu;
        public InputAction @Eating => m_Wrapper.m_Player_Eating;
        public InputAction @Flashlight => m_Wrapper.m_Player_Flashlight;
        public InputAction @Walking => m_Wrapper.m_Player_Walking;
        public InputAction @RemoveBattery => m_Wrapper.m_Player_RemoveBattery;
        public InputAction @ActivateHive => m_Wrapper.m_Player_ActivateHive;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Upgrade.started += instance.OnUpgrade;
            @Upgrade.performed += instance.OnUpgrade;
            @Upgrade.canceled += instance.OnUpgrade;
            @AddBattery.started += instance.OnAddBattery;
            @AddBattery.performed += instance.OnAddBattery;
            @AddBattery.canceled += instance.OnAddBattery;
            @EscapeToMenu.started += instance.OnEscapeToMenu;
            @EscapeToMenu.performed += instance.OnEscapeToMenu;
            @EscapeToMenu.canceled += instance.OnEscapeToMenu;
            @Eating.started += instance.OnEating;
            @Eating.performed += instance.OnEating;
            @Eating.canceled += instance.OnEating;
            @Flashlight.started += instance.OnFlashlight;
            @Flashlight.performed += instance.OnFlashlight;
            @Flashlight.canceled += instance.OnFlashlight;
            @Walking.started += instance.OnWalking;
            @Walking.performed += instance.OnWalking;
            @Walking.canceled += instance.OnWalking;
            @RemoveBattery.started += instance.OnRemoveBattery;
            @RemoveBattery.performed += instance.OnRemoveBattery;
            @RemoveBattery.canceled += instance.OnRemoveBattery;
            @ActivateHive.started += instance.OnActivateHive;
            @ActivateHive.performed += instance.OnActivateHive;
            @ActivateHive.canceled += instance.OnActivateHive;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Upgrade.started -= instance.OnUpgrade;
            @Upgrade.performed -= instance.OnUpgrade;
            @Upgrade.canceled -= instance.OnUpgrade;
            @AddBattery.started -= instance.OnAddBattery;
            @AddBattery.performed -= instance.OnAddBattery;
            @AddBattery.canceled -= instance.OnAddBattery;
            @EscapeToMenu.started -= instance.OnEscapeToMenu;
            @EscapeToMenu.performed -= instance.OnEscapeToMenu;
            @EscapeToMenu.canceled -= instance.OnEscapeToMenu;
            @Eating.started -= instance.OnEating;
            @Eating.performed -= instance.OnEating;
            @Eating.canceled -= instance.OnEating;
            @Flashlight.started -= instance.OnFlashlight;
            @Flashlight.performed -= instance.OnFlashlight;
            @Flashlight.canceled -= instance.OnFlashlight;
            @Walking.started -= instance.OnWalking;
            @Walking.performed -= instance.OnWalking;
            @Walking.canceled -= instance.OnWalking;
            @RemoveBattery.started -= instance.OnRemoveBattery;
            @RemoveBattery.performed -= instance.OnRemoveBattery;
            @RemoveBattery.canceled -= instance.OnRemoveBattery;
            @ActivateHive.started -= instance.OnActivateHive;
            @ActivateHive.performed -= instance.OnActivateHive;
            @ActivateHive.canceled -= instance.OnActivateHive;
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

    // Upgrade
    private readonly InputActionMap m_Upgrade;
    private List<IUpgradeActions> m_UpgradeActionsCallbackInterfaces = new List<IUpgradeActions>();
    private readonly InputAction m_Upgrade_CloseMenu;
    public struct UpgradeActions
    {
        private @GameControls m_Wrapper;
        public UpgradeActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseMenu => m_Wrapper.m_Upgrade_CloseMenu;
        public InputActionMap Get() { return m_Wrapper.m_Upgrade; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UpgradeActions set) { return set.Get(); }
        public void AddCallbacks(IUpgradeActions instance)
        {
            if (instance == null || m_Wrapper.m_UpgradeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UpgradeActionsCallbackInterfaces.Add(instance);
            @CloseMenu.started += instance.OnCloseMenu;
            @CloseMenu.performed += instance.OnCloseMenu;
            @CloseMenu.canceled += instance.OnCloseMenu;
        }

        private void UnregisterCallbacks(IUpgradeActions instance)
        {
            @CloseMenu.started -= instance.OnCloseMenu;
            @CloseMenu.performed -= instance.OnCloseMenu;
            @CloseMenu.canceled -= instance.OnCloseMenu;
        }

        public void RemoveCallbacks(IUpgradeActions instance)
        {
            if (m_Wrapper.m_UpgradeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUpgradeActions instance)
        {
            foreach (var item in m_Wrapper.m_UpgradeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UpgradeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UpgradeActions @Upgrade => new UpgradeActions(this);
    public interface IMenuActions
    {
        void OnCloseMenu(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnUpgrade(InputAction.CallbackContext context);
        void OnAddBattery(InputAction.CallbackContext context);
        void OnEscapeToMenu(InputAction.CallbackContext context);
        void OnEating(InputAction.CallbackContext context);
        void OnFlashlight(InputAction.CallbackContext context);
        void OnWalking(InputAction.CallbackContext context);
        void OnRemoveBattery(InputAction.CallbackContext context);
        void OnActivateHive(InputAction.CallbackContext context);
    }
    public interface IUpgradeActions
    {
        void OnCloseMenu(InputAction.CallbackContext context);
    }
}
