using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Health : MonoBehaviour
{
   /* private int maxHealth = 100;
    private int currentHealth;
    public event Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth-=dmg;
        if(currentHealth<0) currentHealth=0;
        if (currentHealth <= 0) Die();
    }
    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
    public bool IsAlive() => currentHealth > 0; 
   */
}
