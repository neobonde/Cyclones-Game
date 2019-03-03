using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    EdgeCollider2D top;
    CapsuleCollider2D box;

    void Awake()
    {
        top = GetComponent<EdgeCollider2D>();
        box = GetComponent<CapsuleCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && other.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            top.enabled = false;
            Debug.Log("hi");
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        top.enabled = true;
    }


}
