using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static int score;
    public static bool won;

    public TMP_Text textbox;
    public int ScoreToWin;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        won = false;
        textbox.text = "Score: " + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score.ToString();
        }
        if (score >= ScoreToWin)
        {
            won = true;
            gameOver = true;
        }
        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You Win!\nFinal Score: " + score.ToString() + "\nPress R to Restart";
            }
            else
            {
                textbox.text = "Game Over!\nFinal Score: " + score.ToString() + "\nPress R to Restart";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
