using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLeft : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    public float runSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetFloat("Speed", 1);
    }

    float yvel = 0;
    // Update is called once per frame
    void Update()
    {

        yvel = rb.velocity.y;
        rb.velocity = new Vector2(runSpeed, yvel);
    }
}
