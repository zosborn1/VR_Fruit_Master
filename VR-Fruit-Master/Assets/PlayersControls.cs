//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayersControls.inputactions
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

public partial class @PlayersControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayersControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayersControls"",
    ""maps"": [
        {
            ""name"": ""GamePause"",
            ""id"": ""4a052ea6-ab4a-4109-b44f-a30d9782e64f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""88d60223-28be-4377-92af-73be5c6fe867"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StartScene"",
                    ""type"": ""Button"",
                    ""id"": ""4239e8da-7ca5-4e0d-add9-3e7c6b4e5499"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""71ebb47a-d1e2-4d01-b1da-37e71b2aebc0"",
                    ""path"": ""<OculusTouchController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""062bdddf-01ba-4fab-b829-d78b7b01e86b"",
                    ""path"": ""<OculusTouchController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePause
        m_GamePause = asset.FindActionMap("GamePause", throwIfNotFound: true);
        m_GamePause_Pause = m_GamePause.FindAction("Pause", throwIfNotFound: true);
        m_GamePause_StartScene = m_GamePause.FindAction("StartScene", throwIfNotFound: true);
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

    // GamePause
    private readonly InputActionMap m_GamePause;
    private List<IGamePauseActions> m_GamePauseActionsCallbackInterfaces = new List<IGamePauseActions>();
    private readonly InputAction m_GamePause_Pause;
    private readonly InputAction m_GamePause_StartScene;
    public struct GamePauseActions
    {
        private @PlayersControls m_Wrapper;
        public GamePauseActions(@PlayersControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GamePause_Pause;
        public InputAction @StartScene => m_Wrapper.m_GamePause_StartScene;
        public InputActionMap Get() { return m_Wrapper.m_GamePause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePauseActions set) { return set.Get(); }
        public void AddCallbacks(IGamePauseActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePauseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePauseActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @StartScene.started += instance.OnStartScene;
            @StartScene.performed += instance.OnStartScene;
            @StartScene.canceled += instance.OnStartScene;
        }

        private void UnregisterCallbacks(IGamePauseActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @StartScene.started -= instance.OnStartScene;
            @StartScene.performed -= instance.OnStartScene;
            @StartScene.canceled -= instance.OnStartScene;
        }

        public void RemoveCallbacks(IGamePauseActions instance)
        {
            if (m_Wrapper.m_GamePauseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePauseActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePauseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePauseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePauseActions @GamePause => new GamePauseActions(this);
    public interface IGamePauseActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnStartScene(InputAction.CallbackContext context);
    }
}
