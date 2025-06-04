using UnityEngine;

public class Destroy : MonoBehaviour
{

    private float topBound = 35;
    private float bottomBound = -20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
