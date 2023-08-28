using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        Vector3 newRespawnPosition = Vector3.zero;

        // Find the latest collected checkpoint position among all respawn checkpoints
        foreach (var checkpointScript in respawnCheckpointScripts)
        {
            if (checkpointScript.HasBeenCollected())
            {
                newRespawnPosition = checkpointScript.GetCheckpointPosition();
            }
        }

        if (newRespawnPosition != Vector3.zero)
        {
            respawnPosition = newRespawnPosition;
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

    public void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer method called");

        if (respawnPosition != Vector3.zero)
        {
            Debug.Log("Teleporting player to respawn position");
            Player.transform.position = respawnPosition;
        }
        else
        {
            Debug.Log("Teleporting player to world spawn position");
            Player.transform.position = WorldSpawn.position;
        }
    }

}



