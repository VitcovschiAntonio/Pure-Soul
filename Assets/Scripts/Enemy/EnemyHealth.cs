using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float _healthPoints = 100f;
    private float _currentHealth;

    void Start()
    {
        _currentHealth = _healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_currentHealth);
    }
    public void TakeDamage(float damage)
    {
        if(_currentHealth > 0f)
        {
            _currentHealth -= damage;
        }
        else{
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
