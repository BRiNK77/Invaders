using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawned && other.gameObject.CompareTag("Player"))
        {
            spawned = true;
            boss.SetActive(true);
        }
    }
}
