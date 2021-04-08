using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private float radius = 3f;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Wolf.Instance.transform.position);

        if (distanceToPlayer < radius)
            Wolf.Instance.IsHome = true;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}