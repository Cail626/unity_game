using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public static PlayerHealth instance;

    public HealthBar healthBar;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de PlayerHealth" +
                "dans la scène");
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void HealPlayer(int amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }
}
