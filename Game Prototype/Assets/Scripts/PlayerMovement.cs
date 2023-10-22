using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to Rigidbody component
    public Rigidbody rb;
    // Left/right movement speed
    public float dodgeSpeed = 5;
    // Forward movement speed
    public float rollSpeed = 5;

    public enum MobileHorizMovement
    {
        Accelerometer,
        ScreenTouch
    }

    public MobileHorizMovement horizMovement = MobileHorizMovement.Accelerometer;

    private float CalculateMovement(Vector3 pixelPos)
    {
        var worldPos = Camera.main.ScreenToViewportPoint(pixelPos);

        float xMove = 0;

        if (worldPos.x < 0.5f)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }

        return xMove * dodgeSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Accessing the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called at a fixed framerate
    void FixedUpdate()
    {
        //Check for side movement
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

        horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        if (Input.GetMouseButton(0))
        {
            horizontalSpeed = CalculateMovement(Input.mousePosition);
        }

        #elif UNITY_IOS || UNITY_ANDROID

        if(horizMovement == MobileHorizMovement.Accelerometer)
        {
            horizontalSpeed = Input.acceleration.x * dodgeSpeed;
        }

        if (Input.touchCount > 0)
        {
            if (horizMovement == MobileHorizMovement.ScreenTouch)
            {
                Touch touch = Input.touches[0];
                horizontalSpeed = CalculateMovement(touch.position);
            }
            
        }
        #endif
        //Add force during side movement
        rb.AddForce(horizontalSpeed * Time.deltaTime, 0, rollSpeed * Time.deltaTime);
    }
}
