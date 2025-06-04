using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public float rotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(input * rotateSpeed * Time.deltaTime * Vector3.up);
    }
}
