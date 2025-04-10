using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public float maxSpeed = 10f, maxForce = 5f;

    protected Vector3 velocity, acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;

        // Calculate a new Steering force vector
        Vector3 steeringForce = CalcSteering();

        // Add Steering force to Acceleration
        acceleration += steeringForce;

        //  Limit Acceleration force
        acceleration = Vector3.ClampMagnitude(acceleration, maxForce);

        // Update Velocity with current Acceleration
        velocity += acceleration * Time.deltaTime;

        //  Move to new Position
        transform.position += velocity * Time.deltaTime;

    }

    protected abstract Vector3 CalcSteering();

    public Vector3 Seek(Vector3  targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - velocity;

        // Return seek steering force
        return seekingForce;
    }

    public Vector3 Seek(GameObject target)
    {
        // Call the other version of Seek 
        //   which returns the seeking steering force
        //  and then return that returned vector. 
        return Seek(target.transform.position);
    }

    public Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate flee steering force
        Vector3 fleeingForce = desiredVelocity - velocity;

        // Return flee steering force
        return fleeingForce;
    }

    public Vector3 CalcFuturePosition(float time)
    {
        return transform.position + (velocity * time);
    }

}
