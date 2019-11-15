using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Player Movement script that uses Input.GetAxis to determine direction for
// the transform of the player model, also applies gravity
public class Movement : MonoBehaviour
{
    public Animator anim;
    public float speed = 6.0f;
    public float rotSpeed = 2.0f;
    public float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    void Start()
    {
        // gets character controller and animator components for movement
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // gets player input for movement
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");

        // sets animation floats
        anim.SetFloat("speed", forward);
        anim.SetFloat("horiz", sideways);

        // uses the input from player to set a new vector3, (x, y, z)
        // x axis for moving sideways, y for up and down, z is forward or backwards
        moveDirection = new Vector3(0, 0, forward);

        // sets rotation for the player with sidways input * the rotation speed variable
        transform.Rotate(0, sideways * rotSpeed, 0);

        // uses new direction on the transform of the player
        moveDirection = transform.TransformDirection(moveDirection);

        // applies speed to movement transform
        moveDirection *= speed; 

        // applies gravity to player
        moveDirection.y -= gravity * Time.deltaTime;

        // sends movement to player every frame
        controller.Move(moveDirection * Time.deltaTime);

        
    }
}
