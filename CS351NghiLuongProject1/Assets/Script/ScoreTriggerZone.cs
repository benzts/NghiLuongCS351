using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active&&collision.gameObject.tag=="Player")
        {
            //deactivate to prevent multiple scoring
            active = false;
            //add score
            ScoreManager.score++;
            //after scoring, destroy the trigger zone
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
