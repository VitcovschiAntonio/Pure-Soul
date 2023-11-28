using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerAnimations _playerAnimations;
    


    void Awake()
    {
       _playerInput = GetComponent<PlayerInput>();
       _playerMovement = GetComponent<PlayerMovement>();
       _playerAnimations = GetComponent<PlayerAnimations>();
       
    }
    void OnEnable()
    {
        // input to mechanics
        _playerInput.OnMoveInput += _playerMovement.OnMovementInput; 
        _playerInput.OnDashInput += _playerMovement.OnDashInput;

        //Animations
        _playerMovement.OnPlayerRun += _playerAnimations.OnPlayerMove;
        _playerMovement.OnPlayerStopedMoving += _playerAnimations.OnPlayerStopMoving;
        _playerMovement.OnPlayerDash += _playerAnimations.OnPlayerDash;

        // Sounds
        //TODO:

        // vfx
        //TODO:
        
    }
    void OnDisable()
    {
        _playerInput.OnMoveInput -= _playerMovement.OnMovementInput;
        _playerInput.OnDashInput -= _playerMovement.OnDashInput;

        //Aniamtions
       _playerMovement.OnPlayerRun -= _playerAnimations.OnPlayerMove;
       _playerMovement.OnPlayerStopedMoving -= _playerAnimations.OnPlayerStopMoving;
        _playerMovement.OnPlayerDash -= _playerAnimations.OnPlayerDash;

        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
