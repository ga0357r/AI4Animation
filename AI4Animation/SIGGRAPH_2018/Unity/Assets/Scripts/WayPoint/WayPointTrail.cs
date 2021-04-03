using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointTrail : MonoBehaviour
{
    [SerializeField] private Waypoints waypoint; 
    //[SerializeField] private Transform startPoint;
    //[SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int waypointIndex = 0;
    private ParticleSystem particleSys;
    private float startTime;
    private float journeyLength;
    public int WayPointIndex { get { return waypointIndex; } set { waypointIndex = value; } }


    private void Awake()
    {
        particleSys = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(waypoint.wayPoints[waypointIndex].startPoint.position, waypoint.wayPoints[waypointIndex].endPoint.position);
    }

    private void Update()
    {
        StartWayPointTrail();

        if (transform.position == waypoint.wayPoints[waypointIndex].endPoint.position)
            ResetWayPointTrail();
    }

    private void ResetWayPointTrail()
    {
        particleSys.Pause();
        transform.position = waypoint.wayPoints[waypointIndex].startPoint.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(waypoint.wayPoints[waypointIndex].startPoint.position, waypoint.wayPoints[waypointIndex].endPoint.position);
    }

    private void StartWayPointTrail()
    {
        if (!particleSys.isPlaying)
            particleSys.Play();

        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(waypoint.wayPoints[waypointIndex].startPoint.position, waypoint.wayPoints[waypointIndex].endPoint.position, fractionOfJourney);
    }
}
