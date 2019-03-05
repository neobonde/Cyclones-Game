using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{

    BoxCollider2D col;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }


}
