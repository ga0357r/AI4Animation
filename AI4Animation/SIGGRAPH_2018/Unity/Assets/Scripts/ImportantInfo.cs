using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantInfo : MonoBehaviour
{
    private static ImportantInfo instance;
    [SerializeField] private float waitTime = 0f;
    [SerializeField] private float maxWaitTime = 0f;
    public static ImportantInfo Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

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
