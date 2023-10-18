//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/MarioActions.inputactions
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

public partial class @MarioActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MarioActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MarioActions"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""c30f90db-eaa1-467a-9457-5e19274490a2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0a904a60-dcb6-43ef-978d-5f0bd5c2f9f8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""32c48054-1401-48e6-859b-0f744392b547"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JumpHold"",
                    ""type"": ""Button"",
                    ""id"": ""dd1c681b-6a45-417a-a54d-9852d0c1b987"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.3)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""click"",
                    ""type"": ""Button"",
                    ""id"": ""f428d856-dbbd-451a-9658-929e447b6a5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""point"",
                    ""type"": ""Value"",
                    ""id"": ""e6726144-4c90-42cf-b60c-1ba47c4c39e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""424a6c26-c9e3-4002-b577-ded1047f6e42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a3cd3882-329e-4252-a65d-4a0e44fe4701"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""97907479-3532-4892-b460-a3855cd17e2a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a3110793-0532-4389-9d6f-348b7a77051d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0d4a3ae7-cfc1-4215-abad-364fedc279aa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis (Arrow)"",
                    ""id"": ""bddb3e89-de65-40a9-8ce5-10434b61ecf2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e536a925-1f67-4280-88ed-10db66078cb7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0ad355ca-7b75-4a08-beb7-730fc897059f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a466e96-e297-40a6-aa1a-6300aa524a68"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6560d3ba-ec67-4735-8be2-19093028b89b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""JumpHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9708b8f-ff7b-4e91-997c-b9bb3f50634d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SMB"",
                    ""action"": ""click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c5bedfd-73f4-409d-8c51-a66315fec962"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""495da169-663a-4baa-8b3d-76e0cc9e3eb9"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""point"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""ea41be4e-4a23-4332-90c2-4e6cff1c0a09"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SMB"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""93bb2d02-cd1d-4554-9f8f-d1d3efce419e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SMB"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""ba17adc7-6cf6-4e3f-bad9-6b3ce7b0669c"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""point"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""1f26b43b-d024-4651-8e78-2e7fd1fe6272"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""81cd6480-9a37-4777-8c99-05b908602386"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d2afacbd-8e14-43c2-88fb-3a583025ec17"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""SuperMarioBros"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""SuperMarioBros"",
            ""bindingGroup"": ""SuperMarioBros"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""SMB"",
            ""bindingGroup"": ""SMB"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_Move = m_gameplay.FindAction("Move", throwIfNotFound: true);
        m_gameplay_Jump = m_gameplay.FindAction("Jump", throwIfNotFound: true);
        m_gameplay_JumpHold = m_gameplay.FindAction("JumpHold", throwIfNotFound: true);
        m_gameplay_click = m_gameplay.FindAction("click", throwIfNotFound: true);
        m_gameplay_point = m_gameplay.FindAction("point", throwIfNotFound: true);
        m_gameplay_Fire = m_gameplay.FindAction("Fire", throwIfNotFound: true);
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

    // gameplay
    private readonly InputActionMap m_gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_gameplay_Move;
    private readonly InputAction m_gameplay_Jump;
    private readonly InputAction m_gameplay_JumpHold;
    private readonly InputAction m_gameplay_click;
    private readonly InputAction m_gameplay_point;
    private readonly InputAction m_gameplay_Fire;
    public struct GameplayActions
    {
        private @MarioActions m_Wrapper;
        public GameplayActions(@MarioActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_gameplay_Jump;
        public InputAction @JumpHold => m_Wrapper.m_gameplay_JumpHold;
        public InputAction @click => m_Wrapper.m_gameplay_click;
        public InputAction @point => m_Wrapper.m_gameplay_point;
        public InputAction @Fire => m_Wrapper.m_gameplay_Fire;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @JumpHold.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpHold;
                @JumpHold.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpHold;
                @JumpHold.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJumpHold;
                @click.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @click.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @click.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @point.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPoint;
                @point.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPoint;
                @point.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPoint;
                @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @JumpHold.started += instance.OnJumpHold;
                @JumpHold.performed += instance.OnJumpHold;
                @JumpHold.canceled += instance.OnJumpHold;
                @click.started += instance.OnClick;
                @click.performed += instance.OnClick;
                @click.canceled += instance.OnClick;
                @point.started += instance.OnPoint;
                @point.performed += instance.OnPoint;
                @point.canceled += instance.OnPoint;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    private int m_SuperMarioBrosSchemeIndex = -1;
    public InputControlScheme SuperMarioBrosScheme
    {
        get
        {
            if (m_SuperMarioBrosSchemeIndex == -1) m_SuperMarioBrosSchemeIndex = asset.FindControlSchemeIndex("SuperMarioBros");
            return asset.controlSchemes[m_SuperMarioBrosSchemeIndex];
        }
    }
    private int m_SMBSchemeIndex = -1;
    public InputControlScheme SMBScheme
    {
        get
        {
            if (m_SMBSchemeIndex == -1) m_SMBSchemeIndex = asset.FindControlSchemeIndex("SMB");
            return asset.controlSchemes[m_SMBSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpHold(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
