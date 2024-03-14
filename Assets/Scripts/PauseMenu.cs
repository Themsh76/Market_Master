using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameisPaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


   public void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause () 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
}
