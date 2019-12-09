using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public RectTransform healthBarFill;
    private GameObject player;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerHealth>().GetHealth();
        SetHealthAmount(health);
    }

    void SetHealthAmount(float amount)
    {
        healthBarFill.localScale = new Vector3(amount, 1f, 1f);
    }
}
