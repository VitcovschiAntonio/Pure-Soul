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

    public void OnPlayerMove()
    {
        _animator.SetBool("isRunning",true);
    }
    public void OnPlayerStopMoving()
    {
        _animator.SetBool("isRunning",false);
    }
    public void OnPlayerDash(bool dashInput)
    {
       
        _animator.SetBool("canDash", dashInput);
        
    }
}
