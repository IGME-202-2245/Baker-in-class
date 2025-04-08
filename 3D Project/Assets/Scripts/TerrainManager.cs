using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public TerrainData terrainData;

    public float perlicStep = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        float[,] heights = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        float xCoord = 0f, yCoord = 0f;


        for(int x = 0; x < terrainData.heightmapResolution; ++x)
        {
            for (int y = 0; y < terrainData.heightmapResolution; ++y)
            {
                heights[x, y] = Mathf.PerlinNoise(xCoord, yCoord);

                yCoord += perlicStep;
            }

            yCoord = 0f;
            xCoord += perlicStep;
        }


        //  Change terrain data
        terrainData.SetHeights(0, 0, heights);
    }
}
