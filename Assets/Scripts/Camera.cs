using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    Vector3 player_pos;
    Vector3 offset = new Vector3(0f, 1.4f, -4f);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = player.transform.position;
    }

    private void LateUpdate()
    {
        this.transform.position = player_pos + offset;
    }
}
