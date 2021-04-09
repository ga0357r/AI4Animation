using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float maxWaitTime = 2f;

    private void Update()
    {
        waitTime += Time.deltaTime;

        if (waitTime >= maxWaitTime)
        {
            waitTime = 0f;
            gameObject.SetActive(false);
        }
    }
}
