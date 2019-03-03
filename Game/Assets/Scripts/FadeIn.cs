using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    public bool start = true;
    public float fadeSpeed = 0.1f;

    float audioVolume = 0.0f;

    float finalVolume;
    AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        finalVolume = audio.volume;
        audio.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            fadeIn();
        }
    }

    void fadeIn() 
    {
     if (audioVolume < finalVolume) { 
         audioVolume += fadeSpeed * finalVolume * Time.deltaTime;
         audio.volume = audioVolume;
     }
 }
}
