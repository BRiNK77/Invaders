using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
  
    public GameObject bullet1Prefab;
    public int damage = 1; // damage done by this bullet


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Enemy"))
        {
            collision.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(this);
        }
    }



}
