using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    // Reference to RigidBody on this GameObject
    public Rigidbody rBody;

    // Fields for Speed
    public float maxSpeed, minSpeed;

    // Fields for Acceleration/Deceleration
    public float accelerationRate, decelerationRate;

    // Fields for Turning
    public float turnSpeed;

    // Fields for Input
    Vector3 movementDirection;

    // Fields for Movement Vectors
    [SerializeField]
    Vector3 velocity, acceleration;

    // Fields for Quaternions
    Quaternion turning;

    public Vector3 rayOrigin, rayDirection;
    public LayerMask terrainLayer;
    public RaycastHit terrainHit;


    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        /*// Use Input to calc current speed for this frame
        float currentSpeed = movementDirection.z * maxSpeed;

        // Fields for Quaternions
        velocity = transform.forward * currentSpeed;*/

        //  Check for ray hit
        Physics.Raycast(rayOrigin, rayDirection, out terrainHit, 1000f, terrainLayer);

        //  Calc current turning
        turning = Quaternion.Euler(0f, movementDirection.x * turnSpeed * Time.fixedDeltaTime, 0f);

        //  Calc current Turning
        Quaternion nextRotation = transform.rotation * turning;


        // Reset acceleration
        acceleration = Vector3.zero;

        if (movementDirection.z != 0f)
        {
            // Use Input to calc current acceleration for this frame
            acceleration = transform.forward * (movementDirection.z * accelerationRate);

            // Add Acceleration to Velocity
            velocity += acceleration * Time.fixedDeltaTime;

            // Clamp Velocity
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            //	Remove a percentage of the Velocity based on Time
            velocity *= 1f - (decelerationRate * Time.fixedDeltaTime);

            //  Stop the vehicle when it reaches a certain speed
            if (velocity.magnitude < minSpeed)
            {
                velocity = Vector3.zero;
            }
        }


        //  Turn the Vehicle's Velocity
        velocity = turning * velocity;




        // Scale the Velocity to be based on Time not Frame rate
        Vector3 delta = velocity * Time.fixedDeltaTime;


        Vector3 myPos = transform.position;

        if (terrainHit.point != null && terrainHit.point != Vector3.zero)
        {
            myPos = terrainHit.point;
        }


        // Move the Vehicle
        rBody.Move(myPos + delta, nextRotation);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        movementDirection.z = input.y;
        movementDirection.x = input.x;
    }
}
