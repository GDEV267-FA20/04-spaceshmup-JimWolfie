using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ships.events;

public class Enemy : MonoBehaviour
{
    //movement stats
    public Ship_Stats stats;
    

    //movement methods
    //weapons
    [Header("Set in Inspector")]
    [NonSerialized] public float _speed;
    [NonSerialized] public float _fireRate;
    [NonSerialized] public float _health;
    [NonSerialized] public int _score; 
    [NonSerialized] public float powerUpDropChance;

    public float showDamageDuration = 1f;
    public Color[] orginalColors;
    public Material[] materials;
    public bool showingDamage = false;
    public float damageDoneTime;
    public bool notifiedOfDestruction = false;
    [SerializeField]private VoidEvent onDestruction;

    protected BoundsCheck bndCheck;

  
    private void Awake()
    {

        _speed = stats.speed;
        _fireRate =stats.fireRate;
        _health = stats.health;
        _score = stats.score;
        powerUpDropChance = stats.powerUpDropChance;
        bndCheck = GetComponent<BoundsCheck>();
        materials = Utils.GetAllMaterials(gameObject);
        orginalColors = new Color[materials.Length];
        for(int i=0; i<materials.Length; i++)
        {
            orginalColors[i] = materials[i].color;
        }
    }

    public Vector3 pos
    {
        get {
            return(this.transform.position);
        }
        set {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();
        if(showingDamage && Time.time >damageDoneTime)
        {
            UnShowDamage();
        }
        if(bndCheck != null && bndCheck.offDown)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Debug.Log("Fired");
        Vector3 tempPos = pos;
        tempPos.y -= _speed*Time.deltaTime;
        pos=tempPos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        switch(otherGO.tag)
        {
            case"ProjectileHero":
                Projectile p = otherGO.GetComponent<Projectile>();
                if(!bndCheck.isOnScreen)
                {
                    Destroy(otherGO);
                    break;
                }
                _health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                ShowDamage();
                if(_health<=0)
                {
                if(!notifiedOfDestruction)
                {
                    Raise();
                    Main.S.shipDestroyed(this);

                }
                    notifiedOfDestruction = true;
                    Destroy(this.gameObject);
                }
                Destroy(otherGO);
                break;
            default:
                print("enemy hit by non projectileHero "+otherGO.name);
                break;
        }
    }
    void ShowDamage()
    {
        foreach(Material m in materials)
        {
            m.color = Color.red;
        }
        showingDamage = true;
        damageDoneTime = Time.time +showDamageDuration;
        
      
    }
    void UnShowDamage()
    {
        for(int i=0; i<materials.Length; i++)
        {
            materials[i].color=orginalColors[i];
        }
        showingDamage = false;
    }
    protected virtual void Raise()
    {
        onDestruction.FireEvent();
    }

}
