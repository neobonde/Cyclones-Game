using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    [HideInInspector]
    public bool collected = false;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && collected == false)
        {
            Debug.Log(other);
            collected = true;
            sr.enabled = false;
        }
    }

}
