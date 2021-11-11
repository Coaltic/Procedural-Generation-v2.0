using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;

    public List<GameObject> cubes = new List<GameObject>();
    //public GameObject[] cubes;

    public int chunkSize = 16;
    const float scale = 20f;
    public float offsetX;
    public float offsetZ;

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

        for (int x = 0 + (a * chunkSize); x <= chunkSize + (a * chunkSize); x++)
        {
            for (int z = 0 + (b * chunkSize); z <= chunkSize + (b * chunkSize); z++)
            {
                float y = CalculateHeight(x, z);
                GameObject newCube = Instantiate(grass, new Vector3(x, (Mathf.RoundToInt(y * scale)) + 5, z), Quaternion.identity);
                cubes.Add(newCube);

                y = Mathf.RoundToInt(y * scale) + 5;
                while (y >= 0)
                {
                    y--;
                    newCube = Instantiate(dirt, new Vector3(x, y, z), Quaternion.identity);
                    //newCube.transform.localScale = new Vector3(1, y, 1);
                    //newCube.transform.position = new Vector3(x, (y / 2) + 0.5f, z);
                    cubes.Add(newCube);

                }

                
            }

           
        }
    }

    public float CalculateHeight(int x, int z)
    {
        float xCoord = (float)x / chunkSize + offsetX;
        float zCoord = (float)z / chunkSize + offsetZ;

        return Mathf.PerlinNoise(xCoord, zCoord);
    }
}
