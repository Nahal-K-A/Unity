using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] spawns;
    float spawnRangeX = 15;
    float spawnPosZ = 30;
    float spawnDelay = 2;
    float spawnFreq = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RandomSpawner", spawnDelay, spawnFreq);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomSpawner()
    {
        int spawnIndex = Random.Range(0, spawns.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX + 1), 0, spawnPosZ);
        Instantiate(spawns[spawnIndex], spawnPos, spawns[spawnIndex].transform.rotation);
    }
}
