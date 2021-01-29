using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed,runspeed,walkspeed,gravity,jumpheight;
    public CharacterController controller;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;
    public bool isrunning;


    Vector3 velocity;

    bool isgorunded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isgorunded = Physics.CheckSphere(groundcheck.position, groundDistance, groundmask);

        if (isgorunded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgorunded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);

        }

        if (Input.GetKey(KeyCode.LeftShift) && isgorunded)
        {            
            speed = runspeed;

        }
        else
        {
            speed = walkspeed;
            
        }
    }
}
