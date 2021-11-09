using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public TerrainGenerator terrainGenerator;



    void Start()
    {
        GenerateMap();

        //terrainGenerator.GenerateChunk(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    public void GenerateMap()
    {
        foreach (GameObject newCube in terrainGenerator.cubes)
        {
            Destroy(newCube);
        }

        terrainGenerator.cubes.Clear();

        for (int x = 0; x <= 0; x++)
            for (int y = 0; y <= 0; y++)
            {
                terrainGenerator.GenerateChunk(x, y);
            }
    }

    public void ReGenerateMap()
    {
        foreach (GameObject newCube in terrainGenerator.cubes)
        {
            Destroy(newCube);
        }

        terrainGenerator.cubes.Clear();
    }
}
