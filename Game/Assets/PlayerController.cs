using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(hInput,0.0f);

        


        rb.velocity += movement*speed*Time.deltaTime;
        

        // rb.MovePosition(movement*speed*Time.deltaTime);

        // rb.AddRelativeForce(movement*speed*Time.deltaTime);

    }
}
