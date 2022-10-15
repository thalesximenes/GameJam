using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    public float Speed;
    public float MaxAcceleration;
    public float MaximumControlAngle;
    public float MinimumControlAngle;
    public float RotationControl;

    Rigidbody2D rb;


    float Acceleration = 6;
    float MovY, MovX = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.rotation <= MaximumControlAngle && rb.rotation >= MinimumControlAngle)
        {
            MovY = Input.GetAxis("Vertical");
        }
        else MovY = 0;
        if (!Input.GetButton("Vertical")){
            if (rb.rotation > 1 ) {
                MovY = -0.3f;
            } else if (rb.rotation < -1 ) MovY = 0.3f;
        }
                
        
        if  (rb.rotation > MaximumControlAngle && Input.GetAxis("Vertical") < 0)
        {
            MovY = Input.GetAxis("Vertical");
        }
        else if (rb.rotation < MinimumControlAngle && Input.GetAxis("Vertical") > 0)
        {
            MovY = Input.GetAxis("Vertical");
        }
        
        if ((Input.GetAxis("Horizontal") > 0 && Acceleration < 0 && Input.GetButtonDown("Horizontal"))  || ((Input.GetAxis("Horizontal") < 0 && Acceleration > 0  && Input.GetButtonDown("Horizontal")))){
            Acceleration *= -1;
        }
    }

    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * (MovX * Acceleration);
        rb.AddForce(Vel);

        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(Acceleration > 0 )
        {
            if(Dir > 0)
            {
                rb.rotation += MovY * RotationControl * (rb.velocity.magnitude / Speed);
            }
            else 
            {
                rb.rotation -= MovY * RotationControl * (rb.velocity.magnitude / Speed);
            }
        }

        if(Acceleration < 0 )
        {
            if(Dir > 0)
            {
                rb.rotation -= MovY * RotationControl * (rb.velocity.magnitude / Speed);
            }
            else 
            {
                rb.rotation += MovY * RotationControl * (rb.velocity.magnitude / Speed);
            }
        }

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if(rb.velocity.magnitude > Speed)
        {
            rb.velocity = rb.velocity.normalized * Speed;
        }
    }
}
