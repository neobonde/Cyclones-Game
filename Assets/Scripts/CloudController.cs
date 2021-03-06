﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    [Range(0,100)]
    public float floatAcceleration = 100f;
    [Range(0,20)]
    public float floatSpeed = 5f;
    Rigidbody2D rb;

    [HideInInspector]
    public Transform player;

    [HideInInspector]
    public PowerViewer powerViewer;

    float timeout = 0.0f;
    float timeSinceLastJump = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(Vector2.up * 200);
    }


    Vector2 movement;

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetButtonDown("Jump") && player != null)
        {
            if(timeSinceLastJump < 0.2)
            {
                LeaveCloud();
            }
            timeSinceLastJump = 0;
        }

        timeSinceLastJump += Time.deltaTime;

        timeout -= Time.deltaTime;
        if( timeout < 0)
        {
            timeout = 0;
        }

        powerViewer.power -= rb.velocity.magnitude*0.001f;

        if(powerViewer.power <= 0 )
        {
            LeaveCloud();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity += movement * Time.deltaTime * floatAcceleration;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, floatSpeed);
    }

    Rigidbody2D rbPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " Collided with: " + other.name);
        if(other.tag != "Player" && timeout <= 0)
        {
            if(player != null && other.tag !="Wall")
            {
                LeaveCloud();
            }

        }
    }

    

    void LeaveCloud()
    {
        rbPlayer = player.GetComponent<Rigidbody2D>();
        rbPlayer.isKinematic = false;
        player.GetComponent<PlayerController>().EnableAll();
        player.parent = null;
        // rbPlayer.velocity = rb.velocity;
        if(rb.velocity.y >= 0 )
        {
            rbPlayer.velocity = Vector2.up * 200;
        }else{
            // rbPlayer.velocity = Vector2.up * 200;
            rbPlayer.velocity = rb.velocity;// + Vector2.up * 10;
        }
        
        Destroy(gameObject);
    }

}
