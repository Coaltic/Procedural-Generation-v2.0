using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public TerrainGenerator terrainGenerator;
    public CaveGenerator caveGenerator;


    void Start()
    {
        terrainGenerator.GenerateOffset();
        GenerateMap();
        caveGenerator.GenerateCaves();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            terrainGenerator.GenerateOffset();
            GenerateMap();
            caveGenerator.GenerateCaves();
        }
    }

    public void GenerateMap()
    {
        foreach (GameObject newCube in terrainGenerator.cubes)
        {
            Destroy(newCube);
        }
        /*foreach (GameObject newCube in terrainGenerator.stone)
        {
            Destroy(newCube);
        }*/

        terrainGenerator.cubes.Clear();
        //terrainGenerator.stone.Clear();

        for (int x = 0; x <= 4; x++)
            for (int y = 0; y <= 4; y++)
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
