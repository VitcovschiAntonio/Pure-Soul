using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private float _attackDamage = 100;
    private bool _isAttacking ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAttacking == true)
        {
            Attack();
        }
        else{
            _isAttacking = false;
        }
    }
    public void OnPlayerAttack(bool value)
    {
        _isAttacking = value;
    }

     public void Attack()
     {
        Vector3 atackPos = transform.position + transform.forward;
        Collider[] enemiesHit = Physics.OverlapSphere(atackPos,1f);

        foreach (var enemy in enemiesHit)
        {
            Debug.Log(enemy.name);
            if(enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);
            }
        }
     }
}
