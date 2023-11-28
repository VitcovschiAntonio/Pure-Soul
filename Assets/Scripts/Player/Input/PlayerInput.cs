
/*Tis script handles only the input for the player*/



using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour // means it can be attached on obj
{
   
    private PlayerInputActions _playerInputActions;

    // input member holders
    private Vector2 _moveInputValue;
    private float _dashInputValue;

     public Action<Vector2> OnMoveInput;
     public Action<float> OnDashInput;
    
    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {   
        //Subscribe event for the _playerInputAction obj.
        _playerInputActions.Enable();

        _playerInputActions.OnFoot.Move.performed += OnMoveInputPerformed;
        _playerInputActions.OnFoot.Move.canceled += OnMoveInputPerformed;

        _playerInputActions.OnFoot.Dash.performed += OnDashInputPerformed;
        _playerInputActions.OnFoot.Dash.canceled += OnDashInputPerformed;


    }
    private void OnDisable()
    {
         //UnSubscribe event for the _playerInputAction obj.
        _playerInputActions.Disable();

        _playerInputActions.OnFoot.Move.performed -= OnMoveInputPerformed;
        _playerInputActions.OnFoot.Move.canceled -= OnMoveInputPerformed;

        _playerInputActions.OnFoot.Dash.performed -= OnDashInputPerformed;
        _playerInputActions.OnFoot.Dash.canceled -= OnDashInputPerformed;

    }

    private void OnMoveInputPerformed(InputAction.CallbackContext ctx)
    {
        _moveInputValue = ctx.ReadValue<Vector2>();
        OnMoveInput(_moveInputValue);
    }
    
    private void OnDashInputPerformed(InputAction.CallbackContext ctx)
    {
        _dashInputValue = ctx.ReadValue<float>();
        OnDashInput(_dashInputValue);
        
    }


    
    
}
