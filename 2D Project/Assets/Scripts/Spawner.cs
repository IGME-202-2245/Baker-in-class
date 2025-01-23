using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;

    public SpriteRenderer spritePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject newGO = Instantiate(spawnPrefab, transform.position, Quaternion.identity);

        newGO.GetComponent<SpriteRenderer>().color = Color.red;



        SpriteRenderer newSprite = Instantiate(spritePrefab, transform.position, Quaternion.identity);


        newSprite.color = Color.red;
    }
}
