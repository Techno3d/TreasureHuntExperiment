using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject treasurePrefab;
    GameObject[] treasurers;
    public int numTreasurers;
    public Rect spawnArea;
    void Start()
    {
        treasurers = new GameObject[numTreasurers];
        for(int i = 0; i < numTreasurers; i++) {
            Vector3 spawn = new Vector3(
                Random.Range(spawnArea.xMin*5, spawnArea.xMax*5),
                20f,
                Random.Range(spawnArea.yMin*5, spawnArea.yMax*5)
                
            );
            treasurers[i] = Instantiate(treasurePrefab, spawn, Quaternion.identity, transform);            

        }
    }
}
