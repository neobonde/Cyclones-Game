using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignFadeIn : MonoBehaviour
{

    [Range(0,10)]
    public float fadeSpeed = 5f;
    [HideInInspector]
    public bool fadeIn = false;
    [HideInInspector]
    public bool fadeOut = false;
    
    TextMeshPro text;
    SpriteRenderer sr;
    
    Color bgColor;
    Color textColor; 


    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        text = transform.Find("Text").GetComponent<TextMeshPro>();
        bgColor = sr.color;
        bgColor.a = 0;
        sr.color = bgColor;

        textColor = text.color;
        textColor.a = 0;
        text.color = textColor;
    }


    float Alpha = 0;

    // Update is called once per frame
    void Update()
    {
        if( fadeIn)
        {
            if (Alpha < 1)
            {
                Alpha += fadeSpeed * Time.deltaTime;
            }else
            {
                fadeIn = false;
            }            
        }else if( fadeOut )
        {
            if (Alpha > 0)
            {
                Alpha -= fadeSpeed * Time.deltaTime;
            }else
            {
                fadeOut = false;
            }
        }

        bgColor.a = Alpha;
        textColor.a = Alpha;

        sr.color = bgColor;
        text.color = textColor;
    }
}
