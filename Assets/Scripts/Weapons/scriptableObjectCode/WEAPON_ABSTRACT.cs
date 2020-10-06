using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class WEAPON_ABSTRACT : ScriptableObject
{
   public WEAPON_DEFINITION wd;
    
    public Projectile MakeProjectile()
    {
        GameObject go = Instantiate<GameObject>(wd.projectilePrefab);
        if(wd.tag)
        {//tag is a bool indicating its a hero. this needs to be an int or something, not a string
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
       
        return (p);
    }

    //running into a power up should add a delagate into a list to call when firing. 
    //each weapon type knows about the delegates it wants
    //weapons know what their power ups look like
    //running over a power up adds the delegate to onFire to the ship. 
    
}
