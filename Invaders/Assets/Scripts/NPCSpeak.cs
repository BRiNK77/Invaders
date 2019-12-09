using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    public GameObject speechBox;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            speechBox.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            speechBox.SetActive(false);
        }
    }
}
