using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public GameObject playerPrefab;

    public void OnTriggerEnter(Collider collider){
      if(collider.gameObject.tag.Equals("Player")){
        PlayerStats.canShoot = true;
        Destroy(this.gameObject);
      }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
