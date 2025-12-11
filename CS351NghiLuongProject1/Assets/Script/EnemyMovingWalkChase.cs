using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class EnemyMovingWalkChase : MonoBehaviour
{
    public float chaseRange = 5f;

    public float moveSpeed = 2f;

    private Transform playerTransform;

    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDirection = playerTransform.position - transform.position;

        float distanceToPlayer = playerDirection.magnitude;

        // Check if the player is within chase range
        if (distanceToPlayer <= chaseRange)
        {
            playerDirection.Normalize();

            playerDirection.y = 0f;

            FacePlayer(playerDirection);

            if (IsGroundAhead())
            {
                //move towards the player
                MoveTowardsPlayer(playerDirection);
            }
            else
            {
                // Stop moving if there's no ground ahead
                StopMoving();
                Debug.Log("No ground ahead, stopping movement.");
            }
        }
        else
        {
            // Stop moving if the player is out of range
            StopMoving();
        }
    }
    bool IsGroundAhead()
    {
        float groundCheckDistance = 2.0f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        Vector2 EnemyFacingDirection = (sr.flipX == false) ? Vector2.left : Vector2.right;

        //raycast to check for ground ahead
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down + EnemyFacingDirection, groundCheckDistance, groundLayer);

        //draw a line to show the raycast in the scene view
        Debug.DrawRay(transform.position, (Vector2.down + EnemyFacingDirection) * groundCheckDistance, Color.red);

        return hit.collider != null;
    }

    private void FacePlayer(Vector2 playerDirection)
    {
        if (playerDirection.x < 0)
        {
            //face left
            sr.flipX = false;
        }
        else if (playerDirection.x > 0)
        {
            //face right
            sr.flipX = true;
        }
    }

        private void MoveTowardsPlayer(Vector2 playerDirection)
        {     
        
            rb.velocity = new Vector2(playerDirection.x * moveSpeed, rb.velocity.y);
            animator.SetBool("IsMoving", true);
        }
        private void StopMoving()
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("IsMoving", false);
        }
}

