using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int enemyCount;
    public GameObject enemy;
    public GameObject powerup;
    private int waveNumber = 1;
    private int powerupCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerup, SpawnPosition(), powerup.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
        powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            if (powerupCount < 3)
            {
                Instantiate(powerup, SpawnPosition(), powerup.transform.rotation);
            }
        }
    }

    private Vector3 SpawnPosition()
    {

        float spawnPosX = Random.Range(-9, 9);
        float spawnPosZ = Random.Range(-9, 9);

        Vector3 spawnPos = new Vector3(spawnPosX, -0.1573641f, spawnPosZ);
        return spawnPos;
    }

    private void SpawnEnemyWave(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemy, SpawnPosition(), enemy.transform.rotation);
        }

    }
}
