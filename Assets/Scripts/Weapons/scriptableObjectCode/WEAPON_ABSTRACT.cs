using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    //become their own scriptable object types, inheriting from weapon. 
    none,
    blaster,
    spread,
    phaser,
    missile,
    laser,
    shield
}

abstract public class WEAPON_ABSTRACT : ScriptableObject
{
    public WeaponType type;
    public string letter;
    public Color color;
    public GameObject projectilePrefab;
    public Color projectileColor;
    public float damageOnHit = 0;
    public float continuousDamage = 0;
    public float delayBetweenShots;
    public float vel;
    // Start is called before the first frame update
    //public abstract void SetType(); returns the delegate for fire
    //public abstract void Fire(); runs the make projectiles
    public virtual Projectile MakeProjectile(GameObject user, Transform PROJECTILE_ANCHOR)
    {
        GameObject go = Instantiate<GameObject>(this.projectilePrefab);
        if(user.transform.parent.gameObject.tag == "Hero")
        {
            go.tag = "ProjectileHero";
            go.layer = LayerMask.NameToLayer("ProjectileHero");
            

        } else
        {
            go.tag = "ProjectileEnemy";
            go.layer = LayerMask.NameToLayer("ProjectileEnemy");
            
        }
        go.transform.position = user.transform.position;
        go.transform.SetParent(PROJECTILE_ANCHOR, true);
        Projectile p = go.GetComponent<Projectile>();
        p.type = type;//gets the asset as reference
        p.rb.velocity = this.vel*Vector3.up;
        return (p);
    }

    //running into a power up should add a delagate into a list to call when firing. 
    //each weapon type knows about the delegates it wants
    //weapons know what their power ups look like
    //running over a power up adds the delegate to onFire to the ship. 
    
}
