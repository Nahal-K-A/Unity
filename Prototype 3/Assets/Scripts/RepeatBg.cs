using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{

    private Vector3 startPos;
    private float halfPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        halfPoint = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - halfPoint)
        {
            transform.position = startPos;
        }
    }
}
