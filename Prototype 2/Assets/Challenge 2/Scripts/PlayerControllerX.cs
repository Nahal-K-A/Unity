using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnCooldown = 2.5f;
    private float nextSpawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextSpawnTime = Time.time + spawnCooldown;
        }


    }
}
