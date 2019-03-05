using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endSound : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);
        audioSource = GetComponent<AudioSource>();
        transform.parent = null;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if(!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
