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
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    public void HighScore()
    {
        if (player.position.z > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", player.position.z);
            highScore.text = player.position.z.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = player.position.z.ToString("0");
        HighScore();
    }
}
