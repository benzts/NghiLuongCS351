/*author: Nghi Luong
 * date: 09/2025
 * description: This script handles player movement and interactions in a 2D platformer game.
 * version: 1.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    // Player movement speed
    public float moveSpeed = 5f;
    // Rigidbody2D component
    private Rigidbody2D rb;
    // Horizontal input
    private float horizontalInput;
    public float jumpForce = 10f;
    private bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public AudioClip jumpsound;
    private AudioSource playerAudio;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck transform is not assigned.");
        }
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       


        //get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpsound, 0.5f);
        }
    }
    void FixedUpdate()
    {
        //set animator parameters XVelocityabs to absolute value of x velocity
        animator.SetFloat("XVelocityAbs", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("YVelocity", rb.velocity.y);

        animator.SetBool("OnGround", isGrounded);

        // Move the player
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //ensure the player faces the correct direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }
}
