using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerAnimations _playerAnimations;
    private PlayerSound _playerSound;

    private PlayerInteraction _playerInteraction;
    
    void Awake()
    {
       _playerInput = GetComponent<PlayerInput>();
       _playerMovement = GetComponent<PlayerMovement>();
       _playerAnimations = GetComponent<PlayerAnimations>();
       _playerSound = GetComponent<PlayerSound>();
       _playerInteraction = GetComponent<PlayerInteraction>();
    }
    
    void OnEnable()
    {
        // input to mechanics
        _playerInput.OnMoveInput += _playerMovement.OnMovementInput; 
        _playerInput.OnDashInput += _playerMovement.OnDashInput;
        _playerInput.OnInteractInput += _playerInteraction.OnInteractInput;


        //Animations
        _playerMovement.OnPlayerRun += _playerAnimations.OnPlayerMove;
        _playerMovement.OnPlayerStopedMoving += _playerAnimations.OnPlayerStopMoving;
        _playerMovement.OnPlayerDash += _playerAnimations.OnPlayerDash;


        //interaction
        
    }
    void OnDisable()
    {
        _playerInput.OnMoveInput -= _playerMovement.OnMovementInput;
        _playerInput.OnDashInput -= _playerMovement.OnDashInput;
        _playerInput.OnInteractInput -= _playerInteraction.OnInteractInput;


        //Aniamtions
       _playerMovement.OnPlayerRun -= _playerAnimations.OnPlayerMove;
       _playerMovement.OnPlayerStopedMoving -= _playerAnimations.OnPlayerStopMoving;
        _playerMovement.OnPlayerDash -= _playerAnimations.OnPlayerDash;

        // Sound
       


        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
