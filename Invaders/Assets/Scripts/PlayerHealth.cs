using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage()
    {
        playerHealth -= 10;
        if (playerHealth <= 0)
            print("dead");
    }

    public float GetHealth()
    {
        return playerHealth / 100.0f;
    }
}
