using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //movement stats
    public Ship_Stats stats;
    public Ship_Move moves;
    public ShipWeaponSubscriber gun;
    //movement methods
    //weapons
    [Header("Set in Inspector")]
    public float speed =10f;
    public float fireRate = .3f;
    public float health =10f;
    public int score = 100;
    public float showDamageDuration = 0.1f;
    public float powerUpDropChance = 1f;

    public Color[] orginalColors;
    public Material[] materials;
    public bool showingDamage = false;
    public float damageDoneTime;
    public bool notifiedOfDestruction = false;


    protected BoundsCheck bndCheck;

    private void Awake()
    {
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
        Vector3 tempPos = pos;
        tempPos.y -= speed*Time.deltaTime;
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
                health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                ShowDamage();
                if(health<=0)
                {
                if(!notifiedOfDestruction)
                {
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

}
