using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject Player;
    public Transform[] SpawnPoints; // An array of spawn points
    public Transform WorldSpawn; // The original world spawn point
    public Checkpoint checkpointScript;

    private int lastCheckCount = 0;
    private int spawnIndex = 0;

    private void Start()
    {
        // Find the Checkpoint script if it's not assigned in the Inspector
        if (checkpointScript == null)
        {
            checkpointScript = GameObject.FindObjectOfType<Checkpoint>();
            if (checkpointScript == null)
            {
                Debug.LogWarning("No Checkpoint script found!");
            }
        }
    }

    private void Update()
    {
        if (checkpointScript.CheckCount > lastCheckCount)
        {
            lastCheckCount = checkpointScript.CheckCount;

            // Use modulo to cycle through the spawn points
            spawnIndex = (lastCheckCount - 1) % SpawnPoints.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (checkpointScript.HasBeenCollected())
            {
                // Teleport the player to the stored checkpoint position
                Player.transform.position = checkpointScript.GetCheckpointPosition();
            }
            else
            {
                // Teleport the player to the original world spawn
                Player.transform.position = WorldSpawn.position;
            }
        }
    }
}

