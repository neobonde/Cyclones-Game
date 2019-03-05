using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerViewer : MonoBehaviour
{

    public float power = 0;
    GameObject player;
    Image progressbar;

    // Start is called before the first frame update
    void Awake()
    {
        progressbar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().powerViewer = this;
        player.GetComponent<PlayerCollisionController>().powerViewer = this;
        progressbar.fillAmount = power;
    }

    // Update is called once per frame
    void Update()
    {
        progressbar.fillAmount = power;   
    }
}
