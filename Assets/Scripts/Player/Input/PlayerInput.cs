
/*Tis script handles only the input for the player*/



using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour // means it can be attached on obj
{
   
    private PlayerInputActions _playerInputActions;

    // input value holders
    private Vector2 _moveInputValue;
    private float _dashInputValue;
    private float _attackInputValue;
    private float _interactInputValue;

    // delegates events
     public Action<Vector2> OnMoveInput;
     public Action<float> OnDashInput;
     public Action<float> OnAttackInput;
     public Action<float> OnInteractInput;
    
    void Awake()
    {
        Application.targetFrameRate = 60;

        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {   
        //Subscribe event from the _playerInputAction obj action map to the methods
        // that recieves these inputs from different classes ex (Movement, interact, combat)

        _playerInputActions.Enable();

        _playerInputActions.OnFoot.Move.performed += OnMoveInputPerformed;
        _playerInputActions.OnFoot.Move.canceled += OnMoveInputPerformed;

        _playerInputActions.OnFoot.Dash.performed += OnDashInputPerformed;
        _playerInputActions.OnFoot.Dash.canceled += OnDashInputPerformed;

        _playerInputActions.OnFoot.Attack.performed += OnAttackInputPerformed;
        _playerInputActions.OnFoot.Attack.canceled += OnAttackInputPerformed;

        _playerInputActions.OnFoot.Interact.performed += OnInteractInputPerformed;
        _playerInputActions.OnFoot.Interact.canceled += OnInteractInputPerformed;


    }
    private void OnDisable()
    {
         //UnSubscribe event for the _playerInputAction obj.
        _playerInputActions.Disable();

        _playerInputActions.OnFoot.Move.performed -= OnMoveInputPerformed;
        _playerInputActions.OnFoot.Move.canceled -= OnMoveInputPerformed;

        _playerInputActions.OnFoot.Dash.performed -= OnDashInputPerformed;
        _playerInputActions.OnFoot.Dash.canceled -= OnDashInputPerformed;

        _playerInputActions.OnFoot.Attack.performed -= OnAttackInputPerformed;
        _playerInputActions.OnFoot.Attack.canceled -= OnAttackInputPerformed;

        _playerInputActions.OnFoot.Interact.performed -= OnInteractInputPerformed;
        _playerInputActions.OnFoot.Interact.canceled -= OnInteractInputPerformed;
        

    }

    // methods that transfers the input recived from OnEnable and calls the event with values recieved
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

    private void OnAttackInputPerformed(InputAction.CallbackContext ctx)
    {
        _attackInputValue = ctx.ReadValue<float>();
        OnAttackInput(_attackInputValue);
    }

    private void OnInteractInputPerformed(InputAction.CallbackContext ctx)
    {
        _interactInputValue = ctx.ReadValue<float>();
        OnInteractInput(_interactInputValue);
    }


    
    
}
