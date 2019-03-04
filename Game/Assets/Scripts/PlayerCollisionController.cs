using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
    Transform respawnPoint;
    [HideInInspector]
    public PowerViewer powerViewer;
    public AudioSource audioSource;
    public Animator animator;
    
    Transform feet;
    void Awake()
    {
        animator = GetComponent<Animator>();
        feet = transform.Find("Feet");
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        transform.position = respawnPoint.position;
    }

    void Start()
    {
    }

    bool dead = false;
    float time;
    void Update()
    {
        if(dead)
        {
            Debug.Log(time);
            if (time <= 0 )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            time -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if(feet.position.y < -5)
        {
            restart();
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            restart();
        }
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            restart();
        }
        if(other.gameObject.tag == "Potion")
        {
            powerViewer.power += 0.1f;
            Destroy(other.gameObject);
        }
    }


    void restart()
    {
        //Posible death animation here!
        audioSource.Play();
        Debug.Log("You have died!");
        time = 0.2f;
        dead = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        GetComponent<PlayerController>().enabled = false;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        animator.SetBool("Dead", true);
    }

}
