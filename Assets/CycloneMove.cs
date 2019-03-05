using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloneMove : MonoBehaviour
{

    public Transform leftBound;
    public Transform rightBound;
    
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        leftBound.parent = null;
        rightBound.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < leftBound.position.x)
        {
            speed = -speed;
        }
        if(transform.position.x > rightBound.position.x)
        {
            speed = -speed;
        }

        transform.Translate(new Vector2(speed * Time.deltaTime,0));
    }
}
