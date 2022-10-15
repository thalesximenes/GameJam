using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    //private float _horizontalInput = 0;
    //private float _verticalInput = 0;

    private Vector2 movement;

    public float movementSpeed = 6;
    //public float rotationSpeed = 6;

    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        //RotatePlayer();
    }

    private void GetPlayerInput(){
        //_horizontalInput = Input.GetAxisRaw("Horizontal");
        //_verticalInput = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    } 

    private void MovePlayer()
    {

        //rb.velocity = transform.right * (_horizontalInput) * movementSpeed;
        //print(_horizontalInput);
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

    }

    //private void RotatePlayer()
    //{
    //    float rotation = _verticalInput * rotationSpeed;
    //    transform.Rotate((Vector3.forward) * rotation);
    //}
}
