using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    public KeyController key;

    SpriteRenderer sr;
    BoxCollider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (key.collected)
        {
            sr.enabled = false;
            col.enabled = false;
        }
    }
}
