using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public GameObject target;

    [SerializeField]
    float seekWeight = 10f;

    protected override Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        totalForce += Seek(target) * seekWeight;

        return totalForce;
    }
}
