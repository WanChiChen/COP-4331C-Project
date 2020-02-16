using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Variable to hold the player object
    public Transform player;
    public Vector3 currentPosition;

    void Start()
    {
        currentPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set camera position equal to player position
        this.transform.position = player.position + currentPosition;
    }
}
