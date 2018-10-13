using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    // Transforms to act as start and end markers for the journey.
    public Vector3 startMarker = new Vector3(0f,0f,0f);
    public Vector3 endMarker = new Vector3(0f, 10f, 0f);

    // Movement speed in units/sec.
    private float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    bool is_zoom = false;
    public float journeyTime = 1f;

    void Start()
    {
        // Keep a note of the time the movement started.
        //startTime = Time.time;

        // Calculate the journey length.
        //journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    // Follows the target position like with a spring
    void Update()
    {
        if (is_zoom)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;
            print(fracJourney);
            if(fracJourney >= 1)
            {
                is_zoom = false;
            }

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
    }

    public void Zoomout(float zoom_distance)
    {
        startMarker = transform.position;
        endMarker = new Vector3(0f, zoom_distance, 0f);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
        speed = journeyLength / journeyTime;
        is_zoom = true;
    }

    public void Zoom(float zoom_distance)
    {
        startMarker = transform.position;
        endMarker = new Vector3(0f, zoom_distance, 0f);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
        speed = journeyLength / journeyTime;
        is_zoom = true;
    }
}
