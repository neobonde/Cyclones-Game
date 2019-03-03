using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclone : MonoBehaviour
{

    public float pushMuliplier = 5f;

    Rigidbody2D rb;
    Jump jump; 
    Vector2 velocity;

    void FixedUpdate()
    {
        if(rb != null)
        {
            // if (rb.velocity.y < 0)
            // {
            //     // rb.AddForce(upForce*2);
            // }else
            if(rb.gameObject.tag == "Player")
            {
                rb.velocity += Vector2.up * -Physics2D.gravity.y * ( pushMuliplier - 1 ) * Time.deltaTime;
                // rb.AddForce(upForce);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Entered!");
        rb = other.GetComponent<Rigidbody2D>();
        jump = other.GetComponent<Jump>();
        if(jump != null) { jump.externalForce = true;}
        // velocity = rb.velocity;
        // if(velocity.y > 0 )
        // {
        //     velocity.y = 0;
        //     rb.velocity = velocity;
        // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Exit!");
        // if(jump != null) { jump.externalForce = false;}
        rb = null;
    }

}
