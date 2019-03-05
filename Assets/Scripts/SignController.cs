using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    SignFadeIn zoomedSign;

    void Awake()
    {
        zoomedSign = transform.Find("Zoomed").GetComponent<SignFadeIn>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            zoomedSign.fadeIn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            zoomedSign.fadeOut = true;
        }
    }
}
