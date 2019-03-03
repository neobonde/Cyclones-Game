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
    public GameObject CyclonePowerUp;


    Vector2 movement;
    Rigidbody2D rb;
    Rect levelBounds;
    Jump jump;
    bool stopMovement = true;
    Vector2 vel;
    float acceleration = 0;
    Animator animator;
    SpriteRenderer sr;
    Transform feet;
    GameObject powerUp;
    int JumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        feet = transform.Find("Feet").transform;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        levelBounds = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Level>().bounds;
        // Debug.Log(levelBounds);
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

        if(Input.GetButtonDown("Jump"))
        {
            JumpCount ++;
        }
        else if(!jump.getInAir())
        {
            JumpCount = 0;
        }

        if(JumpCount == 2 && Input.GetButtonDown("Jump") && powerUp == null)
        {
            Debug.Log("GO!");
            powerUp = Instantiate(CyclonePowerUp);
            powerUp.transform.position = feet.position;
            powerUp.GetComponent<Rigidbody2D>().velocity = rb.velocity/4;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            transform.parent = powerUp.transform;
            powerUp.GetComponent<CloudController>().player = transform;
            animator.SetFloat("Speed",0);
            DisableAll();
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


    public void DisableAll()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Jump>().enabled = false;
        GetComponent<PlayerCollisionController>().enabled = false;
        enabled = false;
    }

    public void EnableAll()
    {
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Jump>().enabled = true;
        GetComponent<PlayerCollisionController>().enabled = true;
        enabled = true;

    }
}
