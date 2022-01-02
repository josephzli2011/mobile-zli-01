using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float startHealth = 100f;
    public RectTransform healthBar;
    float health;
    public UnityEvent onDie;
    public void Die()
    {
        Destroy(gameObject);
    }
    private void Awake()
    {
        health = startHealth;
    }
    private void Update()
    {
        if(healthBar)
            healthBar.localScale = new Vector3(health / startHealth, 1, 1);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if (healthBar)
                healthBar.localScale = new Vector3(health / startHealth, 1, 1);
            onDie.Invoke();
        }
    }
}
