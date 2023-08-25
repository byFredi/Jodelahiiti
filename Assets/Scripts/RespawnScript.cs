using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject Player;
    public Transform WorldSpawn;
    public List<Checkpoint> respawnCheckpointScripts = new List<Checkpoint>();

    private Vector3 respawnPosition = Vector3.zero;

    private void Start()
    {
        if (respawnCheckpointScripts.Count == 0)
        {
            Debug.LogWarning("No Respawn Checkpoint scripts found!");
        }
    }

    private void Update()
    {
        // Find the latest collected checkpoint position among all respawn checkpoints
        foreach (var checkpointScript in respawnCheckpointScripts)
        {
            if (checkpointScript.HasBeenCollected())
            {
                respawnPosition = checkpointScript.GetCheckpointPosition();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (respawnPosition != Vector3.zero)
            {
                Player.transform.position = respawnPosition;
            }
            else
            {
                Player.transform.position = WorldSpawn.position;
            }
        }
    }

    // Add this method to allow updating respawn position externally (from Checkpoint script)
    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }
}

