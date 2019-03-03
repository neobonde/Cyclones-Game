using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    float h;


    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        if(h > 0)
        {
            sr.flipX = false;
        }
        else if (h < 0)
        {
            sr.flipX = true;
        }
    }
}
