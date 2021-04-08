using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwitcher : MonoBehaviour
{
    [SerializeField] private float sphereRadius;
    [SerializeField] private WayPointTrail wayPointTrail;
    [SerializeField] private float distance;
    [SerializeField] private ImportantInfo importantInfo;

    private void Update()
    {
        distance = Vector3.Distance(transform.position, Wolf.Instance.transform.position);

        if (distance <= sphereRadius)
        {
            wayPointTrail.WayPointIndex++;

            string name = transform.name;
            switch (name)
            {
                case "Waypoint Switcher_1":
                    Enemies.Instance.Enemy[0].gameObject.SetActive(true);
                    importantInfo.gameObject.SetActive(true);
                    break;
                case "Waypoint Switcher_5":
                    Enemies.Instance.Enemy[1].gameObject.SetActive(true);
                    importantInfo.gameObject.SetActive(true);
                    break;
                case "Waypoint Switcher_7":
                    Enemies.Instance.Enemy[2].gameObject.SetActive(true);
                    importantInfo.gameObject.SetActive(true);
                    break;
                case "Waypoint Switcher_8":
                    Enemies.Instance.Enemy[3].gameObject.SetActive(true);
                    importantInfo.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
