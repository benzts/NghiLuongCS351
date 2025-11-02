using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void shoot()
    {
        

        GameObject firedprojectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        //destroy the projectile after 3 seconds to avoid clutter
        Destroy(firedprojectile, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

    }
}
