using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRb;

    public Vector3 walkDirection;
    public Vector3 latestPos;

    public bool jumpingNow = false;
    public bool warkingNow = false;

    public string tagOfFloor = "floor";

    public int jumpPower = 70;
    public int speed = 10;
    public int gravityPower = -50;

    public float x_input, z_input;
    public float slideTime = 0.3f;
    public float turnTime = 0.1f;


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

        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;

        if(Mathf.Abs(diff.x) > 0.001f || Mathf.Abs(diff.z) > 0.001f)
        {
            if (walkDirection == new Vector3(0, 0, 0)) return;
            Quaternion rot = Quaternion.LookRotation(diff);
            rot = Quaternion.Slerp(playerRb.transform.rotation, rot, turnTime);
            this.transform.rotation = rot;
        }

        Gravity();
    }

    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        z_input = Input.GetAxisRaw("Vertical");
        walkDirection = new Vector3(x_input, 0, z_input).normalized;

        //Jump
        if (Input.GetButtonDown("Jump") && !jumpingNow)
            Jump();
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

    void Gravity()
    {
        if (jumpingNow)
        {
            playerRb.AddForce(new Vector3(0, gravityPower, 0));
        }
    }
}