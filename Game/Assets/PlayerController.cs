using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Range(0,100000)]
    public float walkAcceleration = 10000;
    [Range(0,20)]
    public float maxVelocity = 5;
    public bool moveInAir = false;
    public bool driftInAir = true;

    Vector2 movement;
    Rigidbody2D rb;
    Jump jump;
    bool stopMovement = true;

    // Start is called before the first frame update
    void Awake()
    {
        movement = Vector2.zero;
        rb = gameObject.GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
    }


    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            stopMovement = false;
            movement = Vector2.right * Input.GetAxis("Horizontal");
        }
        else
        {
            stopMovement = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!jump.getJumping() || moveInAir)
        {
            if(!stopMovement)
            {
            rb.velocity += movement * walkAcceleration * Time.deltaTime;  

            Vector2 clampVel = rb.velocity;
            clampVel.x = Mathf.Clamp(clampVel.x, -maxVelocity, maxVelocity);

            rb.velocity = clampVel;

            }
            else
            {
                if(!driftInAir || !jump.getJumping())
                {
                    Vector2 vel = rb.velocity;
                    vel.x = 0;
                    
                    rb.velocity = vel;
                }
            }
        }
    }
}
