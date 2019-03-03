using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Range(0,500)]
    public float walkAcceleration = 200;
    [Range(0,500)]
    public float inAirAcceleration = 100;
    [Range(0,20)]
    public float maxVelocity = 5;
    public bool moveInAir = true;
    public bool driftInAir = true;


    Vector2 movement;
    Rigidbody2D rb;
    Rect levelBounds;
    Jump jump;
    bool stopMovement = true;
    Vector2 vel;
    float acceleration = 0;
    Animator animator;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        levelBounds = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Level>().bounds;
        // Debug.Log(levelBounds);
        movement = Vector2.zero;
        rb = gameObject.GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
    }


    float h;
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        if(Input.GetButton("Horizontal"))
        {
            stopMovement = false;
            movement = Vector2.right * h;
        }
        else
        {
            stopMovement = true;
        }

        if(h > 0)
        {
            sr.flipX = false;
        }
        else if (h < 0)
        {
            sr.flipX = true;
        }

        if (!jump.getInAir())
        {
            animator.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        }
        else
        {
            // animator.SetFloat("Speed",0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        acceleration = jump.getInAir()? inAirAcceleration: walkAcceleration;

        if(!jump.getInAir() || moveInAir)
        {
            if(!stopMovement)
            {
            rb.velocity += movement * acceleration * Time.deltaTime;  

            Vector2 clampVel = rb.velocity;
            clampVel.x = Mathf.Clamp(clampVel.x, -maxVelocity, maxVelocity);

            rb.velocity = clampVel;

            }
            else
            {
                if(!driftInAir || !jump.getInAir())
                {
                    Vector2 vel = rb.velocity;
                    vel.x = 0;
                    
                    rb.velocity = vel;
                }
            }
        }
        vel = rb.velocity;

        // if(!levelBounds.Contains(transform.position))
        // {
        //     Debug.Log("test");
        //     rb.velocity = Vector2.zero;
        //     // Vector2 vel = rb.velocity;
        //     // vel.x = 0;
        //     // rb.velocity = vel; 
        // }
    }
}
