using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    private bool isHome = false;
    private bool isCaught = false;
    public static Player Instance { get { return instance; } }
    public bool IsHome { get { return isHome; } set { isHome = value; } }
    public bool IsCaught { get { return isCaught; } set { isCaught = value; } }

    private void Awake()
    {
        instance = this;
    }
}