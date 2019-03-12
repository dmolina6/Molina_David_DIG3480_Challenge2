using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{

    public Vector2 startMarker;
    public Vector2 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, Mathf.PingPong(fracJourney, 1));
    }
}


