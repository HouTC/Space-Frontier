using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLevel : MonoBehaviour {

    public int currentHealth;
    public Text healthText;

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
    }

    public void UpdateHealth()
    {
        healthText.text = "Health Level: " + currentHealth;
    }

    
}

