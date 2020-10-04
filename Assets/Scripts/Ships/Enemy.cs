using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ENEMY_SO sOB;
    public Color[] orginalColors;//render pipeline
    public Material[] materials;//render pipeline
    public bool showingDamage = false; //render pipeline
    public float damageDoneTime; //needs to use render pipeline. 
    public bool notifiedOfDestruction = false; //needs to be an event

    [System.NonSerialized] public float _health;
    [System.NonSerialized] public float _showDamageDuration;
    [System.NonSerialized] public float powerUpDropChance;
    protected BoundsCheck bndCheck;

    private void Awake()
    {
        _health = sOB.health;
        _showDamageDuration = sOB.showDamageDuration;
        powerUpDropChance = sOB.powerUpDropChance;
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
        tempPos.y -= sOB.speed*Time.deltaTime;
        pos=tempPos;
    }

    //
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
        damageDoneTime = Time.time +_showDamageDuration;
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
