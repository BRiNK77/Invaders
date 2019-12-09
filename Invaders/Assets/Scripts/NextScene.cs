using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    //public GameObject nextSceneText;
    //public float time = 2f;


    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag.Equals("Player"))
        {
            Time.timeScale = 0;
            PlayerStats.canShoot = false;
            //nextSceneText.SetActive(true);
            Next();
            //Cursor.lockState = CursorLockMode.None
        }
    }

    public void Next()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Application.loadedLevel + 1);
        Cursor.lockState = CursorLockMode.Locked;
    }


}
