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
        birthSpawn.FireEvent(this.transform.position);
        
    }
    
    

}
