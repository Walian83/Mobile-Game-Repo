using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    public float waitTime = 2.0f;
    public Score score;
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        { 
            Destroy(collision.gameObject);

            Invoke("GameOver", waitTime);

        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
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
