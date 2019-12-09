using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject nextSceneText;
    
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag.Equals("Player"))
        {
            Time.timeScale = 0;
            nextSceneText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    public void Next()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LVL1-TZ");
    }

  
}
