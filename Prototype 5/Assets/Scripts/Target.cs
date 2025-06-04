using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRB;
    private float minSpeed = 11.0f;
    private float maxSpeed = 15.35f;
    private float maxTorque = 18.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -3.0f;

    public int points;

    public ParticleSystem explosion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRB = GetComponent<Rigidbody>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bomb"))
        {
            gameManager.GameOver();
        }
    }

    private void OnMouseDown()
    {

        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            if (gameObject.CompareTag("Bomb"))
            {
                gameManager.GameOver();
                return;
            }
            gameManager.UpdateScore(points);
        }
    }

    private Vector3 RandomForce()
    {
        return new Vector3(Random.Range(-0.25f, 0.25f), 1, 0) * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
