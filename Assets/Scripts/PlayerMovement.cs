using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 1.2f;
    private float jumpingPower = 4f;
    private bool isFacingRight = true;
    private bool isRespawning = false;

    Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0f) // Player is moving horizontally
        {
            animator.SetBool("IsWalking", true); // Set the parameter to true
        }
        else
        {
            animator.SetBool("IsWalking", false); // Set the parameter to false
        }

        if (Input.GetButtonDown("Jump") & IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        Flip();

    }

    public void FixedUpdate()
    {
        if (!isRespawning)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero; // Reset velocity during respawning
        }
    }

    private bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
