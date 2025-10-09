using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject DialogPanel;

    private void OnEnable()
    {
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    // Coroutine to type out the sentences one character at a time
    IEnumerator Type()
    {
        //start with an empty textbox
        textbox.text = "";
        //loop through each character in the current sentence adding one character at a time
        foreach (char letter in sentences[index].ToCharArray())
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {

        continueButton.SetActive(false);
        //if there are more sentences to display
        if (index < sentences.Length - 1)
        {

            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textbox.text = "";
            DialogPanel.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
