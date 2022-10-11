//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Game/Inputs/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerInputs"",
            ""id"": ""598dba9a-fe77-4974-95c0-4ef8148b8355"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4e95e0a6-ea3e-4752-a7e3-1fe471fedd81"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FrontalSingleShoot"",
                    ""type"": ""Button"",
                    ""id"": ""ec22d26e-b4db-4f90-bb26-94743252a047"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightSideTripleShoot"",
                    ""type"": ""Button"",
                    ""id"": ""1a7c8eb2-4504-4b96-9f31-2d138d558080"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftSideTripleShoot"",
                    ""type"": ""Button"",
                    ""id"": ""5a5787d0-cca2-4caa-a937-c2423cba78b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseGameInput"",
                    ""type"": ""Button"",
                    ""id"": ""5badc31e-c844-428e-9023-2c5a1a33da93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1241dc4f-aebe-4525-969a-91e1711b26ba"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""edcc78a2-8bdc-49b0-85cf-8835053c64b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a1f5f0e8-9231-414f-9d22-80f958e1c7c9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf911b35-c314-4bf0-9996-6e664c0e13aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8df681a-712c-45a3-bf74-1d5147e49c23"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3a7d962c-9286-4745-8259-89ad300af0fc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrontalSingleShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f61d283-066f-4b73-872d-1d4e705ece92"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSideTripleShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0db69c98-3775-4dae-8fdc-164054609cbc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGameInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a7a43b8-5375-4ef6-83fd-e96502f4d315"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftSideTripleShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInputs
        m_PlayerInputs = asset.FindActionMap("PlayerInputs", throwIfNotFound: true);
        m_PlayerInputs_Movement = m_PlayerInputs.FindAction("Movement", throwIfNotFound: true);
        m_PlayerInputs_FrontalSingleShoot = m_PlayerInputs.FindAction("FrontalSingleShoot", throwIfNotFound: true);
        m_PlayerInputs_RightSideTripleShoot = m_PlayerInputs.FindAction("RightSideTripleShoot", throwIfNotFound: true);
        m_PlayerInputs_LeftSideTripleShoot = m_PlayerInputs.FindAction("LeftSideTripleShoot", throwIfNotFound: true);
        m_PlayerInputs_PauseGameInput = m_PlayerInputs.FindAction("PauseGameInput", throwIfNotFound: true);
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

    // PlayerInputs
    private readonly InputActionMap m_PlayerInputs;
    private IPlayerInputsActions m_PlayerInputsActionsCallbackInterface;
    private readonly InputAction m_PlayerInputs_Movement;
    private readonly InputAction m_PlayerInputs_FrontalSingleShoot;
    private readonly InputAction m_PlayerInputs_RightSideTripleShoot;
    private readonly InputAction m_PlayerInputs_LeftSideTripleShoot;
    private readonly InputAction m_PlayerInputs_PauseGameInput;
    public struct PlayerInputsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerInputsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInputs_Movement;
        public InputAction @FrontalSingleShoot => m_Wrapper.m_PlayerInputs_FrontalSingleShoot;
        public InputAction @RightSideTripleShoot => m_Wrapper.m_PlayerInputs_RightSideTripleShoot;
        public InputAction @LeftSideTripleShoot => m_Wrapper.m_PlayerInputs_LeftSideTripleShoot;
        public InputAction @PauseGameInput => m_Wrapper.m_PlayerInputs_PauseGameInput;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputsActions instance)
        {
            if (m_Wrapper.m_PlayerInputsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                @FrontalSingleShoot.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnFrontalSingleShoot;
                @FrontalSingleShoot.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnFrontalSingleShoot;
                @FrontalSingleShoot.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnFrontalSingleShoot;
                @RightSideTripleShoot.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRightSideTripleShoot;
                @RightSideTripleShoot.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRightSideTripleShoot;
                @RightSideTripleShoot.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnRightSideTripleShoot;
                @LeftSideTripleShoot.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnLeftSideTripleShoot;
                @LeftSideTripleShoot.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnLeftSideTripleShoot;
                @LeftSideTripleShoot.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnLeftSideTripleShoot;
                @PauseGameInput.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnPauseGameInput;
                @PauseGameInput.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnPauseGameInput;
                @PauseGameInput.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnPauseGameInput;
            }
            m_Wrapper.m_PlayerInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @FrontalSingleShoot.started += instance.OnFrontalSingleShoot;
                @FrontalSingleShoot.performed += instance.OnFrontalSingleShoot;
                @FrontalSingleShoot.canceled += instance.OnFrontalSingleShoot;
                @RightSideTripleShoot.started += instance.OnRightSideTripleShoot;
                @RightSideTripleShoot.performed += instance.OnRightSideTripleShoot;
                @RightSideTripleShoot.canceled += instance.OnRightSideTripleShoot;
                @LeftSideTripleShoot.started += instance.OnLeftSideTripleShoot;
                @LeftSideTripleShoot.performed += instance.OnLeftSideTripleShoot;
                @LeftSideTripleShoot.canceled += instance.OnLeftSideTripleShoot;
                @PauseGameInput.started += instance.OnPauseGameInput;
                @PauseGameInput.performed += instance.OnPauseGameInput;
                @PauseGameInput.canceled += instance.OnPauseGameInput;
            }
        }
    }
    public PlayerInputsActions @PlayerInputs => new PlayerInputsActions(this);
    public interface IPlayerInputsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnFrontalSingleShoot(InputAction.CallbackContext context);
        void OnRightSideTripleShoot(InputAction.CallbackContext context);
        void OnLeftSideTripleShoot(InputAction.CallbackContext context);
        void OnPauseGameInput(InputAction.CallbackContext context);
    }
}
