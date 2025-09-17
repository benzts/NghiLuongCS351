using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerZone : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text output;
    public string TextToDisplay;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.tag == "Player")
        {
            output.text = TextToDisplay;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
