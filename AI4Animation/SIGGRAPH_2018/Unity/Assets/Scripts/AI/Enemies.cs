using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private static Enemies instance;
    [SerializeField] private PeasantManAI[] enemy;
    public PeasantManAI[] Enemy { get { return enemy; } }
    public static Enemies Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
}
