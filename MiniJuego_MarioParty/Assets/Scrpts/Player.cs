using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    

    private Rigidbody rb;
    private bool isGrounded;

    bool floorDetected = false;
    bool isJump = false;
    public float jumpForce = 5.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        Vector3 floor = transform.TransformDirection(Vector3.down);

        if(Physics.Raycast(transform.position, floor, 1.2f))
        {
            floorDetected = true;
            print("Contacto con el suelo");
        }
        else
        {
            floorDetected = false ;
            print("No hay contacto con el suelo");
        }


        isJump = Input.GetButtonDown("Jump");

        if (isJump && floorDetected)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

   
    
}
