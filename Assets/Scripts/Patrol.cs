﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [Range(0,50)]
    public float patrolSpeed = 35.0f;
    public float groundedRayLength = 0.14f;
    public bool edgeDetection = true;
    public List<Transform> edgeSensors;

    List<RaycastHit2D> edgeHits;
    Rigidbody2D rb;
    SpriteRenderer sr;
    RaycastHit2D hit;
    Transform Player;

    bool grounded = false; 
    float flipMultiplier = 1;
    float flipTimeout;
    float flipTimeoutTime = 1;
    Rect levelBounds;

    public bool startFlipped = false;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        flipTimeout = 0;
        levelBounds = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Level>().bounds;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.velocity = Vector2.up * -1;

    }

    void Start()
    {
        if(startFlipped)
        {
            flip();
        }
    }

    void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, groundedRayLength);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        grounded = hit.collider != null &&  Utils.inRange(rb.velocity.y, -0.1f,0.1f) ? true : false;        
        if(grounded)
        {
            Vector2 difference = Player.position - transform.position;
            if(Mathf.Abs(difference.x) < 8)
            {
                rb.velocity = Vector2.right * -patrolSpeed *Time.deltaTime * flipMultiplier;

                if(edgeDetection)
                {
                    foreach (var edgeSensor in edgeSensors)
                    {
                        var hit = Physics2D.Raycast(edgeSensor.position, -Vector2.up, 0.2f);
                        // Debug.Log(hit.collider);
                        if (hit.collider == null && flipTimeout == 0)
                        {
                            flipTimeout = flipTimeoutTime;
                            Debug.Log("edge" + flipTimeout);
                            flip();
                        }
                    }
                    flipTimeout = Mathf.Max(0, flipTimeout - Time.fixedDeltaTime);
                }
            }
        }

        // foreach (var edgeSensor in edgeSensors)
        // {
        //     // Debug.Log("Level bound reached");
        //     if (levelBounds.Contains(edgeSensor.position) && flipTimeout == 0)
        //     {
        //         flipTimeout = flipTimeoutTime;
        //         flip();
        //     }
        //     flipTimeout = flipTimeout <= 0 ? 0 : flipTimeout - Time.deltaTime;
        // }



    }

    void flip()
    {
        transform.RotateAround (transform.position, transform.up, 180f);
        flipMultiplier = -flipMultiplier;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")// || other.gameObject.tag == "Enemy")
        {
            Debug.Log("Wall");
            flip();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
    }
}
