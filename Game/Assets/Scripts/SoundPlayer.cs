using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private List<AudioSource> audioSources;
    private void Awake()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ambience");
        DontDestroyOnLoad(transform.gameObject);

        foreach (Transform child in transform)
        {
            audioSources.Add(child.GetComponent<AudioSource>());    
        }

        if (gos.Length > 1)
        {
            Destroy(gameObject);
        }
        PlayMusic(); 
    }

    public void PlayMusic()
    {
        foreach (AudioSource source in audioSources)
        {
            if (source.isPlaying) continue;
            source.Play();
        }
    }

    public void StopMusic()
    {
        foreach (AudioSource source in audioSources)
        {
            source.Stop();
        }
    }
}
