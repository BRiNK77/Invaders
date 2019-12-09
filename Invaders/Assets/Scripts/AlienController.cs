using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour
{
    NavMeshAgent nm;
    public Transform target;
    public float health = 100;

    private bool isAttacking = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nm = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        nm.SetDestination(target.position);
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist <= 2.5f && !isAttacking)
            Attack();
    }

    public void Attack()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
        target.GetComponent<PlayerHealth>().DoDamage();
    }

    void DoneAttacking()
    {
        isAttacking = false;
    }

    public void TakeDamage(float d)
    {
        health -= d;
        if (health <= 0)
            Destroy(gameObject);
    }
}
