using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);

        if (transform.position.y < -9)
        {
            Destroy(gameObject);
        }
    }
}
