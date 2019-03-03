using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fadeout : MonoBehaviour
{

    float alphaVelocity = 0;
    float alpha = 0;
    Color color;

    Image image;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        image = gameObject.GetComponent<Image>();
        color = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        alpha = Mathf.SmoothDamp(image.color.a, 0.0f, ref alphaVelocity, 1f);
        color.a = alpha;
        image.color = color;
        if(alpha < 0.01f)
        {
            gameObject.SetActive(false);
        }
    }
}
