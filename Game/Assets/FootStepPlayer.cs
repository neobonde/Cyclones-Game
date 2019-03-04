using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepPlayer : MonoBehaviour
{

    public List<AudioClip> footsteps;
    public List<AudioSource> sources;

    Rigidbody2D player;
    Jump jump;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
    }

    int i = 0;

    float Timeout = 0.1f;
    AudioClip clip;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(!jump.getInAir() && Mathf.Abs(player.velocity.x) > 0.1)
        {
            if(Timeout <= 0)
            {
                i = (i + 1)%sources.Count;
                clip = footsteps[Random.Range( 0, footsteps.Count )];
                sources[i].clip = clip;
                sources[i].Play();
                Timeout = speed;
            }
            Timeout -= Time.deltaTime;
            if(Timeout < 0 )
            {
                Timeout = 0;
            }


        }
    }
}
