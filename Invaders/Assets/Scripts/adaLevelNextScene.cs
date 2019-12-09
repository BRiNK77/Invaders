using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class adaLevelNextScene : MonoBehaviour
{
    // Start is called before the first frame update
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
        SceneManager.LoadScene("levelDavid");
    }
}
