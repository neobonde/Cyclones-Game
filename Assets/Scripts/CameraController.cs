﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Vector2 smoothTime = new Vector2(0.05f,0.05f);

    [Header("Camera Bounds only used if level bounds is false")]
    public bool useLevelBounds = true;
    public Rect cameraBounds = new Rect(0,0,10,10);

    Transform player;
    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        if(useLevelBounds)
        {
            cameraBounds = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Level>().bounds;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    float posX, posY, posZ;
    Vector2 velocity;

    void FixedUpdate()
    {
        posX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity.x, smoothTime.x);
        posY = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smoothTime.y);
        posZ = transform.position.z;
        transform.position = new Vector3(posX, posY, posZ);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,cameraBounds.xMin,cameraBounds.xMax),           
            Mathf.Clamp(transform.position.y,cameraBounds.yMin,cameraBounds.yMax),           
            posZ);

    }
}
