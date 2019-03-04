using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    bool gameIsPaused = false;

    public GameObject PauseUI;

    public bool destroyMusic = false;

    void Start()
    {
        Resume();
        if (destroyMusic)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ambience"));
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }else{
                Pause();
            }
        }
    }



    public void Pause()
    {
        if(PauseUI != null)
        {
            gameIsPaused = true;
            PauseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Resume()
    {
        if(PauseUI != null)
        {
            gameIsPaused = false;
            PauseUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void loadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
