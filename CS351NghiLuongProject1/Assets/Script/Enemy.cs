using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    //Health of the enemy
    public int health = 100;

    //a prefab to spawn when the enemy dies
    public GameObject deathEffect;

    //A refrence to the health bar display script
    private DisplayBar HealthBar;

    //damage to the player
    public int damage = 10;

    private void Start()
    {
         animator = GetComponent<Animator>();


        HealthBar = GetComponentInChildren<DisplayBar>();
        

        if (HealthBar == null)
        {
            Debug.LogError("HealthBar (DisplayBar script) not found");
            return;
        }

        HealthBar.setMaxValue(health);
    }

    //damage the player when colliding
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            //
            if (playerHealth == null)
            {
                //player does not have a PlayerHealth script
                Debug.LogError("PlayerHealth script not found on player");
                return;
            }

            playerHealth.TakeDamage(damage);

            playerHealth.knockback(transform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //update health bar
        HealthBar.setValue(health);

        if (animator != null)
        {
            animator.SetBool("Hurt", true);
        }

        if (health <= 0)
        {
            Die();
        }
        //play hurt animation or effect here if needed
        

    }

    public void Die()
    {
        //spawn death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //destroy enemy object
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        

    }
}
