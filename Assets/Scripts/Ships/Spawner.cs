using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    public int numToSpawn = 5;
    void Start()
    {
        this._health = 1;

    }
    public override void Raise()
    { 
       
        for(int i=0; i<= numToSpawn; i++)
        {
            Debug.Log("spawnd");
            base.Raise();
            Debug.Log("not null spwanerl");
        }
       
    }

}
