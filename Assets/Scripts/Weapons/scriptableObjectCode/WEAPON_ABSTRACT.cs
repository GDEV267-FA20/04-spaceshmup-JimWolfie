using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WEAPON_ABSTRACT : ScriptableObject
{
    public string type;
    public string letter;
    public Color color;
    public GameObject projectilePrefab;
    public Color projectileColor;
    public float damageOnHit = 0;
    public float continuousDamage = 0;
    public float delayBetweenShots;
    public float velocity;
    // Start is called before the first frame update
    //public abstract void SetType();set type is redundant because delagates. 
    //public abstract void Fire(); the ship fires, not the weapon
    public abstract Projectile MakeProjectile();

    //running into a power up should add a delagate into a list to call when firing. 
    //each weapon type knows about the delegates it wants
    //weapons know what their power ups look like
    //running over a power up adds the delegate to onFire to the ship. 
    
}
