using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;
    private Renderer rend;
    public WEAPON_DEFINITION wp;

    [Header("set dynamically")]
    public Rigidbody rb;
    [SerializeField]private WeaponType _type;
    public Vector3 attack;

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
    }
    public void SetType(WeaponType eType)
    {
        _type = eType;
        var def = wp.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    }
}
