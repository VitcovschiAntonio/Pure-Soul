using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    private bool _canAttack;

    public Action<bool> OnPlayerAttack;
    public Action OnPlayerStopAttack;

    void Start()
    {
        
    }

    void Update()
    {
        Attack();
    }

    public bool PlayerIsAttacking()
    {
        return _canAttack;
    }

    public void OnAttackInput(float attackInput)
    {
        if (attackInput > 0f)
        {
            _canAttack = true;
        }
        else
        {
            _canAttack = false;
        }
    }

    void Attack()
    {
        if (_canAttack)
        {
            OnPlayerAttack(_canAttack);
            Debug.Log("Attack!");
        }
        else
        {
            OnPlayerStopAttack();
        }
     
    }

    

}
