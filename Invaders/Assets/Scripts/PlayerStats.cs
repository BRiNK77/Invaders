using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int HP = 10;  //  player health
    public float FR = 1f; // fire rate

    public GameObject bulletPrefab; // what bullet to use
    public Transform firePoint; // where the bullets come out
    public static bool canShoot = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
           Shoot();
        }
    }

    void Shoot()
    {

        // makes gameobject, then creates a bullet of the gameobject
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // makes a temp rigidbody to apply force to bullet
        Rigidbody temp;
        temp = bullet.GetComponent<Rigidbody>();
        temp.AddForce(bullet.transform.forward * 3000);

        // destroys bullet after set time if they didnt hit enemy
        Destroy(bullet, 5);

    }

    void setShoot(){
      canShoot = !canShoot;
    }

}
