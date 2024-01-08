using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    public TMP_Text highScore;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        // Loads the player's saved highest score
        highScore.text = ("High Score: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0"));
    }

    public void HighScore()
    {
        // Save the score only if it's bigger than the already saved one
        if (player.position.z > PlayerPrefs.GetFloat("HighScore", 0))
        {
            // Set the high score using the player's position on the Z-axis
            PlayerPrefs.SetFloat("HighScore", player.position.z);
            highScore.text = ("High Score: "+ player.position.z.ToString("0"));
        }
    }

    public void Reset()
    {
        // Button for resetting the high score
        PlayerPrefs.DeleteKey("HighScore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculates the score based on the player's position on the Z-axis and converts it to a string
        scoreText.text = player.position.z.ToString("0");
        HighScore();
    }
}
