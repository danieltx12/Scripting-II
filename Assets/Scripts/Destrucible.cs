using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrucible : MonoBehaviour, IDamageable
{
    private int _currentHealth;
    private int _maxHealth = 1;

    public void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth == 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
