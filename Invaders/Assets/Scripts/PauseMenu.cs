using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            
            if (!pauseMenu.activeInHierarchy)
            {
                PlayerStats.canShoot = false;
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                
            } else if (pauseMenu.activeInHierarchy)
            {
                PlayerStats.canShoot = true;
                ContinueGame();
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
