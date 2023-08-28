using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public int CheckCount { get; private set; }
    private Vector3 checkpointPosition;
    private bool isCollected = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Reference to the RespawnScript instance
    public RespawnScript respawnScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            CheckCount++;
            checkpointPosition = transform.position;
            isCollected = true;

            if (respawnScript != null)
            {
                respawnScript.SetRespawnPosition(checkpointPosition); // Update respawn position
            }

            gameObject.SetActive(false);
        }
    }

    public bool HasBeenCollected()
    {
        return isCollected;
    }

    public Vector3 GetCheckpointPosition()
    {
        return checkpointPosition;
    }
}

