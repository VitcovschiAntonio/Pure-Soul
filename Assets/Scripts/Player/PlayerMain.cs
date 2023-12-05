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
    private PlayerStats _playerStats;
    private PlayerCombat _playerCombat;

    private PlayerWeapon _playerWeapon;
    
    void Awake()
    {
       _playerInput = GetComponent<PlayerInput>();
       _playerMovement = GetComponent<PlayerMovement>();
       _playerAnimations = GetComponent<PlayerAnimations>();
       _playerSound = GetComponent<PlayerSound>();
       _playerInteraction = GetComponent<PlayerInteraction>();
       _playerCombat = GetComponent<PlayerCombat>();
       _playerStats = GetComponent<PlayerStats>();
       _playerWeapon = GetComponentInChildren<PlayerWeapon>();
    }
    
    void OnEnable()
    {
        // input to mechanics
        _playerInput.OnMoveInput += _playerMovement.OnMovementInput; 
        _playerInput.OnDashInput += _playerMovement.OnDashInput;
        _playerInput.OnInteractInput += _playerInteraction.OnInteractInput;
        _playerInput.OnAttackInput += _playerCombat.OnAttackInput; 
        _playerCombat.OnPlayerAttack += _playerMovement.OnPlayerAttack;
        _playerCombat.OnPlayerStopAttack += _playerMovement.OnPlayerStopAttack;
        _playerCombat.OnPlayerAttack += _playerWeapon.OnPlayerAttack;
        


        //Animations
        _playerMovement.OnPlayerRun += _playerAnimations.OnPlayerMove;
        _playerMovement.OnPlayerStopedMoving += _playerAnimations.OnPlayerStopMoving;
        _playerMovement.OnPlayerDash += _playerAnimations.OnPlayerDash;
        _playerCombat.OnPlayerAttack += _playerAnimations.OnPlayerAttack;
        _playerCombat.OnPlayerStopAttack += _playerAnimations.OnPlayerStopAttack;


        //interaction
        
    }
    void OnDisable()
    {
        _playerInput.OnMoveInput -= _playerMovement.OnMovementInput; 
        _playerInput.OnDashInput -= _playerMovement.OnDashInput;
        _playerInput.OnInteractInput -= _playerInteraction.OnInteractInput;
        _playerInput.OnAttackInput -= _playerCombat.OnAttackInput; 
        _playerCombat.OnPlayerAttack -= _playerMovement.OnPlayerAttack;
        _playerCombat.OnPlayerStopAttack -= _playerMovement.OnPlayerStopAttack;
        _playerCombat.OnPlayerAttack -= _playerWeapon.OnPlayerAttack;


        



        //Aniamtions
       _playerMovement.OnPlayerRun -= _playerAnimations.OnPlayerMove;
       _playerMovement.OnPlayerStopedMoving -= _playerAnimations.OnPlayerStopMoving;
        _playerMovement.OnPlayerDash -= _playerAnimations.OnPlayerDash;
        _playerCombat.OnPlayerAttack -= _playerAnimations.OnPlayerAttack;
        _playerCombat.OnPlayerStopAttack -= _playerAnimations.OnPlayerStopAttack;



        // Sound
       


        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
