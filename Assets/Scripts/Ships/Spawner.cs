using ships.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    [SerializeField]private Vector3Event birthSpawn;
    public int numToSpawn = 5;
    void Start()
    {
        this._health = 1;
        
    }
    public override void Raise()
    {
        Debug.Log("spawnd1");
        if(onDestruction !=null)
        {
            Debug.Log("on destruction");
            onDestruction.FireEvent();
        }
        if(birthSpawn != null)
        {
            Vector3 pun = Vector3.zero;
            pun += gameObject.transform.position;
            pun.y += 3;
            pun.x +=2;
            birthSpawn.FireEvent(pun);
            Debug.Log("fired once");
            pun.x -= 4;
            birthSpawn.FireEvent(pun);
            Debug.Log("fired twice");
        }
        
        
    }
    
    

}
