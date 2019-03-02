using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0,10)]
    public float fallMultiplier = 5f;
    
    [Range(0,10)]
    public float slowJumpMultiplier = 2.0f;
    
    [Range(0,10)]
    public float jumpVelocity = 5.0f;

    public bool externalForce = false;

    bool jump = false;
    bool jumping = false;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Jump") && grounded && jumping == false)
        {
            jump = true;
        }
    }

    RaycastHit2D hit;
    bool grounded;
    public float groundedRayLength = 0.33f;
    public float maxYVelocity = 10.0f;

    float maxYVel = 0;
    float maxHeight = -Mathf.Infinity;

    Vector2 vel;

    string s = "none";

    void FixedUpdate()
    {
        if(jump)
        {
            jump = false;
            jumping = true;
            rb.velocity += Vector2.up * jumpVelocity; 
        }
        
        hit = Physics2D.Raycast(transform.position, -Vector2.up, groundedRayLength);
        grounded = hit.collider != null && Utils.inRange(rb.velocity.y, -0.1f,0.1f) ? true : false;

        if(grounded && jumping == true)
        {
            jumping = false;
        }


        if(rb.velocity.y < 0 )
        {
            s = "vel < 0";
            rb.velocity += Vector2.up * Physics2D.gravity.y * ( fallMultiplier - 1 ) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            s = "vel > 0 && !button jump";
            rb.velocity += Vector2.up * Physics2D.gravity.y * ( slowJumpMultiplier - 1 ) * Time.deltaTime; 
        }else
        {
            s = "none";
        }
        
        if(externalForce)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * ( slowJumpMultiplier - 1 ) * Time.deltaTime; 
            s = "external force";
        }

        if(grounded)
        {
            externalForce = false;
        }

        vel = rb.velocity;
        vel.y = Mathf.Clamp(vel.y,-Mathf.Infinity,maxYVelocity);
        rb.velocity = vel;

        if (rb.velocity.y > maxYVel)
        {
            maxYVel = rb.velocity.y;
        }

        if (transform.position.y > maxHeight)
        {
            maxHeight = transform.position.y;
        }
    }

    public bool getInAir()
    {
        return !grounded;
    }

}
