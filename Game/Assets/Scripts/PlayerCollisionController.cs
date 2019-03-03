using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
    Transform respawnPoint;
    [HideInInspector]
    public PowerViewer powerViewer;
    
    Transform feet;
    void Awake()
    {
        feet = transform.Find("Feet");
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        transform.position = respawnPoint.position;
    }

    void Start()
    {
    }

    void Update()
    {
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
        Debug.Log("You have died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
