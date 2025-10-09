using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cam follows player above player head on y axis of the player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z);
        //implement smooth camera movement
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z), Time.deltaTime * 5);
        //make camera look ahead a little bit of player when player is moving without camera jittering
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(player.transform.position.x + (Input.GetKey(KeyCode.D) ? 1 : -1) * 0.5f, player.transform.position.y + 1, transform.position.z);
        }



    }
}
