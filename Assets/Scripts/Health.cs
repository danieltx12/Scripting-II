using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private int _currentHealth;
    private int _maxHealth = 3;
    private bool isInvincible = false;
    public Player player;

    public void Awake()
    {
        _currentHealth = _maxHealth;
        player = GetComponent<Player>();
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            player.DecreaseHealth(damage);
            _currentHealth -= damage;
            StartCoroutine("TempInvuln");
        }
        if(_currentHealth == 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    IEnumerator TempInvuln()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
    }
}
