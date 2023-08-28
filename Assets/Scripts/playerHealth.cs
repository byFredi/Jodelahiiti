using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    // Reference to the RespawnScript instance
    public RespawnScript respawnScript;

    private void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            // Trigger respawn using the RespawnScript
            if (respawnScript != null)
            {
                respawnScript.RespawnPlayer();

                // Restore player's health to maximum after respawning
                health = maxHealth;
            }
        }
    }

}
