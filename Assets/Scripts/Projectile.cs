﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;
    private Renderer rend;

    [Header("set dynamically")]
    public Rigidbody rb;
    [SerializeField]private WeaponType _type;

    public WeaponType type
    {
        get {
            return(_type);
        }
        set {
            SetType(value);
        }
    }

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }
  
    
    void Update()
    {
        if(bndCheck.offUp)
        {
            Destroy(gameObject);
        }
        Vector3 tempPos = transform.position;
        tempPos.y -= 15f*Time.deltaTime;
        
        transform.position=tempPos;
    }
    public void SetType(WeaponType eType)
    {
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    }
}
