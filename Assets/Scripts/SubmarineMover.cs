using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMover : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public SubmarineMovementData movementData;

    private Vector2 movementVector;
    public float currentSpeed = 0;
    public float currentForewardDirection = 1;
    private Vector2 currentLocation = Vector2.zero;
    private Vector2 targetLocation = Vector2.zero;

    Vector2 movement = Vector2.zero;

     private void Awake() 
    {
        rb2d = GetComponentInParent<Rigidbody2D>();    
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        this.targetLocation = Vector2.zero;
        CalculateSpeed(movementVector);
        if  (movementVector.y > 0)
            currentForewardDirection = 1;
        else if (movementVector.y < 0)
            currentForewardDirection = -1;
    }

    public void Towards(Vector2 current, Vector2 target)
    {
        this.currentLocation = current;
        this.targetLocation = target;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {   
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    private void Update() 
    {
        Vector2 direction = this.currentLocation - this.targetLocation;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate() 
    {
        rb2d.velocity = (Vector2)transform.right * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
        print((Vector2)transform.right * currentSpeed * currentForewardDirection * Time.fixedDeltaTime);
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));
        if (targetLocation != Vector2.zero) 
        {
            rb2d.MovePosition((Vector2)transform.position + (movement * movementData.maxSpeed * Time.fixedDeltaTime));
        }
    }

}
