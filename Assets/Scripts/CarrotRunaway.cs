using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotRunaway : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Reference to the Animator component
    private Animator animator;

    private void Start()
    {
        // Initialize the animator by getting the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        // Disable the carrot GameObject initially
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Enable the carrot GameObject when colliding with the player
            gameObject.SetActive(true);

            // Trigger the animation when colliding with the player
            animator.SetBool("IsActive", true); // Set the parameter to true
        }
    }
}
