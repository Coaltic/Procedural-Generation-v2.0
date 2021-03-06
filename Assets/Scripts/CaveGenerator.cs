using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    public TerrainGenerator terrainGenerator;


    //public GameObject cube;
    //public List<GameObject> cubes = new List<GameObject>();

    public float perlinDivision = 6;
    public float noiseScale = 0.125f;

    public float offset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }*/
    }

    public void GenerateCaves()
    {

        foreach (GameObject newCube in terrainGenerator.cubes)
        {
            //Debug.Log(Perlin3D(newCube.transform.position.x * noiseScale, newCube.transform.position.y * noiseScale, newCube.transform.position.z * noiseScale));

            if (Perlin3D(newCube.transform.position.x * noiseScale, newCube.transform.position.y * noiseScale, newCube.transform.position.z * noiseScale) >= 0.5f)
            {
                Destroy(newCube);
                
                //GameObject newCube = Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
                //cubes.Add(newCube);
            }
                    
                
            

        }

    }

    public float Perlin3D(float x, float y, float z)
    {
        float offset = Random.Range(0f, 99999f);

        float ab = Mathf.PerlinNoise(x, y);
        float bc = Mathf.PerlinNoise(y, z);
        float ac = Mathf.PerlinNoise(x, z);

        float ba = Mathf.PerlinNoise(y, x);
        float cb = Mathf.PerlinNoise(z, y);
        float ca = Mathf.PerlinNoise(z, x);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / perlinDivision;
    }
}
