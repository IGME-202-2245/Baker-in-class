using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1demo : MonoBehaviour
{
    public int favNum = 34;

    public Transform followTarget;

    public GameObject camera;

    int randNum = 23423;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody testingCam = camera.GetComponent<Rigidbody>();

        testingCam.mass = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(favNum);

        //transform.position = followTarget.position;


    }
}
