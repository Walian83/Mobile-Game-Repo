using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float moveSpeed;
    //CharacterController ch;
    private Rigidbody rb;
    public float dodgeSpeed = 5;
    public float rollSpeed = 5;

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
        rb.AddForce(0, 0, rollSpeed * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
