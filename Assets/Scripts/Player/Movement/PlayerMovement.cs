/*
    Ideea for better animation controlling : the movement must be liniar interpolated?? and by that I mean it must starts slow going trough 3-4 phases of speed until max speed
*/
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private PlayerMovementData _movementData;
    private Vector2 _movementInput;
    private Rigidbody _rb;
    private bool _canDash;
    private float _maxSpeed;
  
    public Action<float> OnPlayerRun;
    public Action OnPlayerStopedMoving;
    public Action<bool> OnPlayerDash;
    //public Action OnPlayerWalk;
    
    void Start()
    {
       _rb = GetComponent<Rigidbody>();
       _maxSpeed = _movementData.runMaxSpeed;
    }

    void FixedUpdate()
    {
      Move();
      Dash();
      
    }
      
    // recieves input values as a Vector2 in range [-1,1]
    public void OnMovementInput(Vector2  movementInput)
    {
        _movementInput = movementInput;
    } 

    public void OnPlayerAttack(bool atack)
    {    
            _maxSpeed = 4;
    
    }
    public void OnPlayerStopAttack()
    {
        _maxSpeed = _movementData.runMaxSpeed;
    }
    public void OnDashInput(float dashInput)
    {
        if(dashInput > 0f)
        {
            _canDash = true;
        }
        else{
            _canDash = false;
        }
    }

    // Method that handles movemenrt & player rotation
    public void Move()
    {
        //movement
        Vector3 movementDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
        movementDirection.Normalize();
        Vector3 targetSpeed = movementDirection * _maxSpeed;
        
        _rb.velocity = Vector3.Lerp(_rb.velocity, targetSpeed, Time.fixedDeltaTime * _movementData.runAcceleration);

        

        //rotation
        if (movementDirection.magnitude > 0f)
        {
        OnPlayerRun(_rb.velocity.magnitude);
            
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, targetRotation, Time.fixedDeltaTime * _movementData.rotationSpeed));
         }
         else if(movementDirection.magnitude == 0)
         {
            OnPlayerStopedMoving();
         }
    }

    public void Dash()
    {
       
        OnPlayerDash(_canDash);

        _canDash = false;
      } 
}


        
    
  

 

   

  
