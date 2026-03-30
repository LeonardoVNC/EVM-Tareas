using UnityEngine;

public class Clock : MonoBehaviour
{
    private Transform minute; 
    private Transform hour;

    private float velMin = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minute = transform.Find("Minute");
        hour = transform.Find("Hour");

        if (minute == null || hour == null) {
            Debug.LogError("Ayudaporfavor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotMin = velMin * Time.deltaTime;
        minute.Rotate(0,rotMin,0);

        float rotHour = rotMin/12f;
        hour.Rotate(0,rotHour,0);
    }
}
