using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public List<AudioSource> audioSources;
    private void Awake()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Ambience");
        DontDestroyOnLoad(transform.gameObject);

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
