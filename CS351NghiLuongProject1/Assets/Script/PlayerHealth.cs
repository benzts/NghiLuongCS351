using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;

    public DisplayBar healthBar;

    private Rigidbody2D rb;

    public float knockbackForce = 10f;

    public GameObject PlayerDeathEffect;

    public static bool hitRecently = false;

    public float hitRecoveryTime = 0.5f;

    private AudioSource playerAudio;
    public AudioClip playerHitSound;
    public AudioClip playerDeathSound;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player.");
        }

        healthBar.setMaxValue(Health);

        hitRecently = false;



    }


    public void knockback(Vector3 enemyPosition)
    {
        if (hitRecently || Health <= 0) return;

        hitRecently = true;

        StartCoroutine(RecoverFromHit());

        Vector2 direction = transform.position - enemyPosition;

        // Normalize the direction vector
        direction.Normalize();

        // Adjust the y component to make knockback more upward
        direction.y = direction.y * 0.5f + 0.5f;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(hitRecoveryTime);
        hitRecently = false;
        //reset hit animation
        animator.SetBool("Hit", false);

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.setValue(Health);

        
        if (Health <= 0)
        {
            Die();
            

        }
        else
        {
            //play hit sound effect here
            playerAudio.PlayOneShot(playerHitSound, 0.7f);

            //play hit animation here
            animator.SetBool("Hit",true);
        }


    }

    public void Die()
    {
        ScoreManager.gameOver = true;
        //play death sound effect here
        
        //play death animation here

        //Instantiate death effect
        GameObject deathEffect = Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);

        //destroy death effect after 1 second
        Destroy(deathEffect, 1f);


        gameObject.SetActive(false);



    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
