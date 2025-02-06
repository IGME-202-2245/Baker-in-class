using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    //  Degrees per second
    public float spinRate = 360f / 60f;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        transform.Rotate(0f, 0f, spinRate * Time.deltaTime);
    }
}
