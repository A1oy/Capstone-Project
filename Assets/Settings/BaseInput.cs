//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.0
//     from Assets/Settings/BaseInput.inputactions
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

public partial class @BaseInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BaseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BaseInput"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""afc463a0-9e2f-47d1-b24c-b5ad3838ab70"",
            ""actions"": [
                {
                    ""name"": ""Switch Mode"",
                    ""type"": ""Button"",
                    ""id"": ""b76e3763-16bf-467d-b108-4e5eca9d797f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Switch Item"",
                    ""type"": ""Button"",
                    ""id"": ""91a4f239-0171-429c-aeb9-b7343e16a70c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""72e98260-288e-422e-8152-fbf0f6b3105b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""737aed71-afec-4543-89be-37223e3124d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw Honey"",
                    ""type"": ""Button"",
                    ""id"": ""80c8ad53-28e6-423b-ac6a-f2c056cafa0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""bce7f4c8-d0b8-4890-a84d-232b8be24f58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1ccd712c-b3d6-4e00-a732-f17fba2b4317"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c27658e-757c-4cfa-a060-2f4c726210d6"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw Honey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3472bedc-680f-4373-bc90-7662cdc977e8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc607ebf-9d07-48f4-a126-3a39de258057"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbcceb5-8189-44b3-a510-52721484b27a"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d30e297e-8989-4109-b555-680c85f777e8"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6d31788-cfed-4e1e-b2bc-6c132654ccb9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Base"",
            ""id"": ""5cc95374-f42c-4475-8bea-0a3cd2a88f80"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a4ffe089-70fc-4ffd-a617-c2d413093fd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""757458a8-d97e-40a4-8a67-2d18f96e872f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_SwitchMode = m_GamePlay.FindAction("Switch Mode", throwIfNotFound: true);
        m_GamePlay_SwitchItem = m_GamePlay.FindAction("Switch Item", throwIfNotFound: true);
        m_GamePlay_Use = m_GamePlay.FindAction("Use", throwIfNotFound: true);
        m_GamePlay_Throw = m_GamePlay.FindAction("Throw", throwIfNotFound: true);
        m_GamePlay_ThrowHoney = m_GamePlay.FindAction("Throw Honey", throwIfNotFound: true);
        m_GamePlay_Pause = m_GamePlay.FindAction("Pause", throwIfNotFound: true);
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Interact = m_Base.FindAction("Interact", throwIfNotFound: true);
    }

    ~@BaseInput()
    {
        Debug.Assert(!m_GamePlay.enabled, "This will cause a leak and performance issues, BaseInput.GamePlay.Disable() has not been called.");
        Debug.Assert(!m_Base.enabled, "This will cause a leak and performance issues, BaseInput.Base.Disable() has not been called.");
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
    private readonly InputAction m_GamePlay_SwitchMode;
    private readonly InputAction m_GamePlay_SwitchItem;
    private readonly InputAction m_GamePlay_Use;
    private readonly InputAction m_GamePlay_Throw;
    private readonly InputAction m_GamePlay_ThrowHoney;
    private readonly InputAction m_GamePlay_Pause;
    public struct GamePlayActions
    {
        private @BaseInput m_Wrapper;
        public GamePlayActions(@BaseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwitchMode => m_Wrapper.m_GamePlay_SwitchMode;
        public InputAction @SwitchItem => m_Wrapper.m_GamePlay_SwitchItem;
        public InputAction @Use => m_Wrapper.m_GamePlay_Use;
        public InputAction @Throw => m_Wrapper.m_GamePlay_Throw;
        public InputAction @ThrowHoney => m_Wrapper.m_GamePlay_ThrowHoney;
        public InputAction @Pause => m_Wrapper.m_GamePlay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void AddCallbacks(IGamePlayActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
            @SwitchMode.started += instance.OnSwitchMode;
            @SwitchMode.performed += instance.OnSwitchMode;
            @SwitchMode.canceled += instance.OnSwitchMode;
            @SwitchItem.started += instance.OnSwitchItem;
            @SwitchItem.performed += instance.OnSwitchItem;
            @SwitchItem.canceled += instance.OnSwitchItem;
            @Use.started += instance.OnUse;
            @Use.performed += instance.OnUse;
            @Use.canceled += instance.OnUse;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
            @ThrowHoney.started += instance.OnThrowHoney;
            @ThrowHoney.performed += instance.OnThrowHoney;
            @ThrowHoney.canceled += instance.OnThrowHoney;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IGamePlayActions instance)
        {
            @SwitchMode.started -= instance.OnSwitchMode;
            @SwitchMode.performed -= instance.OnSwitchMode;
            @SwitchMode.canceled -= instance.OnSwitchMode;
            @SwitchItem.started -= instance.OnSwitchItem;
            @SwitchItem.performed -= instance.OnSwitchItem;
            @SwitchItem.canceled -= instance.OnSwitchItem;
            @Use.started -= instance.OnUse;
            @Use.performed -= instance.OnUse;
            @Use.canceled -= instance.OnUse;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
            @ThrowHoney.started -= instance.OnThrowHoney;
            @ThrowHoney.performed -= instance.OnThrowHoney;
            @ThrowHoney.canceled -= instance.OnThrowHoney;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePlayActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // Base
    private readonly InputActionMap m_Base;
    private List<IBaseActions> m_BaseActionsCallbackInterfaces = new List<IBaseActions>();
    private readonly InputAction m_Base_Interact;
    public struct BaseActions
    {
        private @BaseInput m_Wrapper;
        public BaseActions(@BaseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Base_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void AddCallbacks(IBaseActions instance)
        {
            if (instance == null || m_Wrapper.m_BaseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BaseActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IBaseActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBaseActions instance)
        {
            foreach (var item in m_Wrapper.m_BaseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BaseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BaseActions @Base => new BaseActions(this);
    public interface IGamePlayActions
    {
        void OnSwitchMode(InputAction.CallbackContext context);
        void OnSwitchItem(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnThrowHoney(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IBaseActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}