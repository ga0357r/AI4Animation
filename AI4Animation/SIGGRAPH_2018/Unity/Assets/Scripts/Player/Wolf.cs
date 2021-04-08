using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private static Wolf instance;
    private bool isHome = false;
    private bool isCaught = false;
    public static Wolf Instance { get { return instance; } }
    public bool IsHome { get { return isHome; } set { isHome = value; } }
    public bool IsCaught { get { return isCaught; } set { isCaught = value; } }

    private void Awake()
    {
        instance = this;
    }
}