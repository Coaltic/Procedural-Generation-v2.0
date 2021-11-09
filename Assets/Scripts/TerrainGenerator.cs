using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;

    public List<GameObject> cubes = new List<GameObject>();
    //public GameObject[] cubes;

    const int chunkSize = 128;
    const float scale = 20f;
    public float offsetX = 100f;
    public float offsetZ = 100f;

    public float y;

    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetZ = Random.Range(0f, 99999f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateChunk(int a, int b)
    {
        offsetX = Random.Range(0f, 99999f);
        offsetZ = Random.Range(0f, 99999f);

        for (int x = 0; x <= chunkSize; x++)
            for (int z = 0; z <= chunkSize; z++)
            {
                float y = CalculateHeight(x, z);
                GameObject newCube = Instantiate(grass, new Vector3(x + (a * chunkSize), Mathf.RoundToInt(y * scale), z + (b * chunkSize)), Quaternion.identity);
                cubes.Add(newCube);

                y = Mathf.RoundToInt(y * scale);
                //while (y >= 0)
                //{
                y--;
                newCube = Instantiate(dirt, new Vector3(x + (a * chunkSize), y, z + (b * chunkSize)), Quaternion.identity);
                newCube.transform.localScale = new Vector3(1, y, 1);
                newCube.transform.position = new Vector3(x, (y / 2) + 0.5f, z);
                cubes.Add(newCube);
                    
                //}


                //Mathf.RoundToInt(y)
            }
    }

    public float CalculateHeight(int x, int z)
    {
        float xCoord = (float)x / chunkSize + offsetX;
        float zCoord = (float)z / chunkSize + offsetZ;

        return Mathf.PerlinNoise(xCoord, zCoord);
    }
}
