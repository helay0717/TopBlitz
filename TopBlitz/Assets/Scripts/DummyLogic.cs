using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyLogic : MonoBehaviour
{
    public float maxHealth = 500;
    public float currentHealth;
    public Slider healthBar; // 체력바 UI

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();

        if (currentHealth == 0)
        {
            Destroy(gameObject); // 체력이 0이 되면 더미를 파괴
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }
}
