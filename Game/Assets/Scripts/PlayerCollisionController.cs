using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{


    Transform respawnPoint;

    void Awake()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        transform.position = respawnPoint.position;
    }

    void Start()
    {
    }

    void Update()
    {
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
    }


    void restart()
    {
        //Posible death animation here!
        Debug.Log("You have died!");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
