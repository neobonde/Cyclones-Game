using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0,10)]
    public float fallMultiplier = 2.5f;
    
    [Range(0,10)]
    public float slowJumpMultiplier = 2.0f;
    
    [Range(0,10)]
    public float jumpVelocity = 5.0f;

    bool jump = false;
    bool jumping = false;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Jump") && jumping == false)
        {
            jump = true;
        }
    }


    void FixedUpdate()
    {
        if(jump)
        {
            jump = false;
            jumping = true;
            rb.velocity += Vector2.up * jumpVelocity; 
        }

        if(rb.velocity.y == 0 && jumping == true)
        {
            jumping = false;
        }

        if(rb.velocity.y < 0 )
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * ( fallMultiplier - 1 ) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            
            rb.velocity += Vector2.up * Physics2D.gravity.y * ( slowJumpMultiplier - 1 ) * Time.deltaTime; 
        }
    }

    public bool getJumping()
    {
        return jumping;
    }

}
