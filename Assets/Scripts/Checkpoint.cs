using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public int CheckCount { get; private set; }
    private bool isCollected = false;
    private Vector3 checkpointPosition; // Store the collected checkpoint's position

    private void Start()
    {
        CheckCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Debug.Log("Collision detected with player.");
            CheckCount++;
            Debug.Log("Checkpoint count: " + CheckCount);
            isCollected = true;
            checkpointPosition = transform.position; // Store the checkpoint's position
            gameObject.SetActive(false); // Hide the checkpoint GameObject
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
