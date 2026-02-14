using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
     public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;

        Debug.Log("Vida actual: " + health);

        if (health <= 0)
        {
            Debug.Log("Buuu maloooo");
        }
    }
}
