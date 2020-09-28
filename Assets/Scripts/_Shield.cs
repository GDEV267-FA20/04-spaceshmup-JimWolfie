using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")]
    public int levelShown =0;

    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    
    void Update()
    {
        
    }
}
