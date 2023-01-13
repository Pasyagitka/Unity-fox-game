using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlowers : MonoBehaviour
{
    private int terrainWidth;
    private int terrainLength; 
    private int terrainPosX;
    private int terrainPosZ;

    public GameObject[] myObjects;

    void Start() 
    {
        Terrain terrain = GetComponent("Terrain") as Terrain;
        terrainWidth = (int)terrain.terrainData.size.x;
        terrainLength = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;
    }

    void Update()
    {
        InstantiateObjects();
    }

    void InstantiateObjects()
    {
        int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
        float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));

        if(Input.GetKeyDown(KeyCode.Space)) {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(posx, posy, posz);

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
