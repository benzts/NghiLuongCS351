using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyflychase : MonoBehaviour
{
    //public references patrol points
    public GameObject[] patrolPoints;

    //public variables
    public float speed;
    public float chaseRange;

    //enemy state enumeration
    public enum EnemyState { Patrolling, Chasing }

    //current enemy state
    public EnemyState currentState = EnemyState.Patrolling;

    public GameObject target;

    private GameObject player;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    //current patrol point index
    private int currentPatrolIndex = 0;




    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");

        //check if patrol points are assigned
        if (patrolPoints.Length == 0 || patrolPoints[0] == null)
        {
            Debug.LogError("No patrol points assigned to enemy.");
        }

        //set initial target to first patrol point
        target = patrolPoints[currentPatrolIndex];

    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        //execute behavior based on current state
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                break;
            case EnemyState.Chasing:
                ChasePlayer();
                break;
        }

        //draw chase range for debugging
        Debug.DrawLine(transform.position, player.transform.position, Color.red);

    }
    void UpdateState()
    {
        if (InChasingRange() && currentState == EnemyState.Patrolling)
        {
            currentState = EnemyState.Chasing;
        }
        else if (!InChasingRange() && currentState == EnemyState.Chasing)
        {
            currentState = EnemyState.Patrolling;
            target = patrolPoints[currentPatrolIndex];
        }
    }

    bool InChasingRange()
    {
        if (player == null)
        {
            Debug.LogError("Player object not found.");
            return false;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= chaseRange;
    }
    void Patrol()
    {
        //check if reached current patrol point
        if (Vector2.Distance(transform.position, target.transform.position) < 0.5f)
        {
            //move to next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
        target = patrolPoints[currentPatrolIndex];
        MoveTowardsTarget();
    }
    void ChasePlayer()
    {
        target = player;
        MoveTowardsTarget();
    }
    void MoveTowardsTarget ()
    {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * speed;
        //face target
        FaceTarget(direction);

    }
    private void FaceTarget(Vector2 direction)
    {
        if (direction.x < 0)
        {
            sr.flipX = false;
        }
        else if (direction.x > 0)
        {
            sr.flipX = true;
        }
    }
    //draw circle to show patrol point
    private void OnDrawGizmos()
    {
        if (patrolPoints != null)
        {
            Gizmos.color = Color.green;
            foreach (GameObject point in patrolPoints)
            {
                if (point != null)
                {
                    Gizmos.DrawWireSphere(point.transform.position, 0.5f);
                }
            }
        }
        
    }
}
