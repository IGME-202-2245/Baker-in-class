using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Rigidbody2D spawnedPrefab;

    public float forceMag;

    public float spawnWaitTime;
    float spawnTimer;

    public float minValue, maxValue;

    public float perlinStepTime;
    float perlinTimer;

    public float gaussianMean, gaussianSTD;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0 )
        {
            Spawn();

            spawnTimer = spawnWaitTime;
        }       
    }

    void Spawn()
    {
        Rigidbody2D newThing = Instantiate(spawnedPrefab, transform.position, Quaternion.identity, transform);

        newThing.AddForce(GetRandomForce());
    }

    Vector3 GetRandomForce()
    {
        Vector3 calcForce = Vector3.zero;

        //  Calc a new random force
        calcForce = transform.up * forceMag;

        //  Rotate force
        calcForce = Quaternion.Euler(0f, 0f, GaussianRandomAngle()) * calcForce;

        return calcForce;
    }

    float PsedoRandomAngle()
    {
        return Random.Range(minValue, maxValue);
    }

    float PerlinRandomAngle()
    {
        perlinTimer += perlinStepTime;

        float randAngle = Mathf.PerlinNoise1D(perlinTimer);

        return Mathf.Lerp(minValue, maxValue, randAngle);
    }

    float GaussianRandomAngle()
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);

        return gaussianMean + (gaussianSTD * gaussValue);
    }

    bool SuccessCheck(float successChance)
    {
        float randValue = Random.value;

        if (randValue <= successChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
