using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLevel : MonoBehaviour {

    public int currentHealth;

    public void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
    }

    
}

