using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRb;

    public Vector3 walkDirection;

    public bool jumpingNow = false;
    public bool warkingNow = false;

    public string tagOfFloor = "floor";

    public int jumpPower = 70;
    public int speed = 10;

    public float x_input, z_input;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Move
        if (playerRb.velocity.magnitude <= 10 && !jumpingNow)
        {
            playerRb.AddForce(walkDirection * speed, ForceMode.VelocityChange);
        }
    }

    void Update()
    {
        x_input = Input.GetAxis("Horizontal");
        z_input = Input.GetAxis("Vertical");
        walkDirection = new Vector3(x_input, 0, z_input).normalized;
        //Jump
        if (Input.GetButtonDown("Jump") && !jumpingNow)
            Jump();

        if(walkDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(walkDirection);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagOfFloor)
        {
            jumpingNow = false;
        }
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        jumpingNow = true;
    }
}