using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public TerrainGenerator terrainGenerator;
    public Generator generator;


    void Start()
    {
        GenerateMap();
        generator.GenerateCaves();
        //terrainGenerator.GenerateChunk(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
            generator.GenerateCaves();
        }
    }

    public void GenerateMap()
    {
        foreach (GameObject newCube in terrainGenerator.cubes)
        {
            Destroy(newCube);
        }

        terrainGenerator.cubes.Clear();

        for (int x = 0; x <= 3; x++)
            for (int y = 0; y <= 3; y++)
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
