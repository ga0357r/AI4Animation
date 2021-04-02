using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwitcher : MonoBehaviour
{
    [SerializeField] private float sphereRadius;
    [SerializeField] private WayPointTrail wayPointTrail;
    [SerializeField] private float distance;

    private void Update()
    {
        distance = Vector3.Distance(transform.position, Player.Instance.transform.position);

        if (distance <= sphereRadius)
        {
            wayPointTrail.WayPointIndex++;
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
