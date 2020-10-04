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
    public abstract void SetType();
    public abstract void Fire();
    public abstract Projectile MakeProjectile();
}
