using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
 

    void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerMove(float speed)
    {
        _animator.SetBool("isRunning",true);
        _animator.SetFloat("Blend",speed);
    }
    public void OnPlayerStopMoving()
    {
        _animator.SetBool("isRunning",false);
    }
    public void OnPlayerDash(bool dashInput)
    {
       
        _animator.SetBool("canDash", dashInput);
        
    }
    
    public void PlayerIsIdle()
    {
        _animator.SetBool("isIdle", true);
    }
    public void OnPlayerAttack(bool attackInput)
    {
        _animator.SetBool("canAttack",attackInput);
    }
    public void OnPlayerStopAttack()
    {
        _animator.SetBool("canAttack", false);
    }
}
