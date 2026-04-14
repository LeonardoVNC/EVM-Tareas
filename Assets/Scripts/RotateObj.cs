using UnityEngine;

public class RotateObj : MonoBehaviour
{
    private float speed = 150f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up*speed*Time.deltaTime, Space.World);
    }
}
