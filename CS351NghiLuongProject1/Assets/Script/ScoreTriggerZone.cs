using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    public AudioClip scoreSound;
    private AudioSource playerAudio;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
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
            Destroy(gameObject, 2.0f);
            //play sound
            playerAudio.PlayOneShot(scoreSound, 1.0f);
            //make it dissapear immediately
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
