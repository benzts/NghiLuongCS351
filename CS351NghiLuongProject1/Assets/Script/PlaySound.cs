using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlaySound : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip soundClip;
    public float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundClip, volume);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
