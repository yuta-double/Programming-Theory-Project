using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody player_rb;

    public int jump_power = 10;
    public int speed = 10;

    public float x_input, z_input;

    public Vector3 moveing;

    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Move
        player_rb.AddForce(moveing * speed);
    }

    void Update()
    {
        x_input = Input.GetAxis("Horizontal");
        z_input = Input.GetAxis("Vertical");
        moveing = new Vector3(x_input, 0, z_input);
        //Jump
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    void Jump()
    {
        player_rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
    }
}
