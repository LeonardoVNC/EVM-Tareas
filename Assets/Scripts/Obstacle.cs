using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private float heightUnit = 0.5f;
    private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Elevate(int level) {
        StopAllCoroutines();
        Vector3 target = new Vector3(transform.position.x, level*heightUnit, transform.position.z);
        StartCoroutine(MoveTo(target));
    }

    IEnumerator MoveTo(Vector3 target) {
        while (Vector3.Distance(transform.position, target) > 0.01f) {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
        transform.position = target;
    }
}
