using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController player;
    public GameObject obstacle;
    private float spawnDelay = 2;
    private float spawnRate = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnRate);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObject()
    {
        if (player.gameOver == false)
        {
            Instantiate(obstacle, transform.position, obstacle.transform.rotation);
        }
    }
}
