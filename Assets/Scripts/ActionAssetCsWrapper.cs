using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionAssetCsWrapper : MonoBehaviour
{
    public MarioActions marioActions;

    void Start()
    {
        marioActions = new MarioActions();
        marioActions.gameplay.Enable();
        marioActions.gameplay.Jump.performed += OnJump;
        marioActions.gameplay.JumpHold.performed += OnJumpHoldPerformed;
        marioActions.gameplay.Move.started += OnMove;
        marioActions.gameplay.Move.canceled += OnMove;
    }

    void OnJump(InputAction.CallbackContext context)
    {
        // Debug.Log("Jump!");
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Debug.Log("move started");
        }
        if (context.canceled)
        {
            // Debug.Log("move stopped");
        }

        float move = context.ReadValue<float>();
        // Debug.Log($"move value: {move}"); // will return null when not pressed

        // TODO
    }
    void OnJumpHoldPerformed(InputAction.CallbackContext context)
    {
        // Debug.Log("Jump hold");
    }
}
