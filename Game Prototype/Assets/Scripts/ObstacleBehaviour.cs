using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    // How long to wait before restarting the game
    public float waitTime = 1.0f;
    public Score score;
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if obstacle collided with the player
        if (collision.gameObject.GetComponent<PlayerMovement>())
        { 
            // Destroy the player
            Destroy(collision.gameObject);
            // Call the GameOver function after waitTime has passed
            Invoke("GameOver", waitTime);

        }
    }
    // Restarts the currently loaded scene/level
    public void GameOver()
    {
        // Reloads the current scene
        SceneManager.LoadScene("Main Menu");
        AdManager.instance.interstitialAds.ShowAd();
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
