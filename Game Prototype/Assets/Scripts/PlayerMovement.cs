using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float moveSpeed;
    //CharacterController ch;
    public Rigidbody rb;
    public float dodgeSpeed = 5;
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
        //ch = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //ch.Move(new Vector3(x, 0, moveSpeed * Time.deltaTime));
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

        rb.AddForce(horizontalSpeed * Time.deltaTime, 0, rollSpeed * Time.deltaTime);

        //if (Input.GetKey("d"))
        //{
        //    rb.AddForce(horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
        //if (Input.GetKey("a"))
        //{
        //    rb.AddForce(horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}
    }
}
