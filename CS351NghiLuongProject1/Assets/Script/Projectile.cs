using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    

    private Rigidbody2D rb;

    public float speed = 20f;

    public int damage = 40;

    public GameObject ImpactEffect;

    // OnTriggerEnter2D is called when the collider other enters the trigger
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        if (hitInfo.gameObject.tag != "Player")
        {
            //spawn impact effect
            Instantiate(ImpactEffect, transform.position, transform.rotation);
            

            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
