using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float _maxHealthPoints;
    private float _currentHealth;
    
    void Start()
    {
        _maxHealthPoints = 100f;
        _currentHealth = _maxHealthPoints;
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
    void Heal(int healPoints)
    {
        if(_currentHealth + healPoints > 100f)
        {
            _currentHealth = 100f;
        }
        else{
            _currentHealth += healPoints;
        }
    }
    void Die()
    {
        if(_currentHealth < 0f)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
