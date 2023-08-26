using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CheckpointHit : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool isCollected = false;
    private Vector3 checkpointPosition;

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
            checkpointPosition = transform.position;
            isCollected = true;
            animator.SetBool("isCollected", true); // Set the parameter to true
        }
        else
        {
            animator.SetBool("isCollected", false); // Set the parameter to false

        }

         

    
    }

     public bool HasBeenCollected()
    {
    return isCollected;
    }
}
