using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public GameObject target;

    protected override Vector3 CalcSteering()
    {
        return Seek(target);
    }
}
