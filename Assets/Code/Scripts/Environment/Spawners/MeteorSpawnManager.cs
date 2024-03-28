using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnManager : MonoBehaviour
{
    public GameObject meteor1Prefab;
    public int meteorAmountPerTimes;
    public int spawnDelay;
    public float x0;
    public float y0;
    public float z0;
    public float x1;
    public float y1;
    public float z1;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnDelay);
    }

    void SpawnMeteor()
    {
        for (int i = 0; i < meteorAmountPerTimes; i++)
        {
            float randomX = Random.Range(x0, x1);
            float randomY = Random.Range(y0, y1);
            float randomZ = Random.Range(z0, z1);
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            Instantiate(meteor1Prefab, spawnPosition, Quaternion.identity);
        }
    }
}
