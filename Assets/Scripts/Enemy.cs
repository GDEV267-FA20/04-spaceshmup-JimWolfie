using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speed =0.2f;
    public float fireRate = .3f;
    public float health =10f;
    public int score = 100;

    private BoundsCheck bndCheck;
    //private bool engaged; //dealing with thing
    //private bool inRange; //already knows about player
    //public Vector3 target;
    

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        //ChooseDirection();
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
        if(bndCheck != null && !bndCheck.isOnScreen)
        {
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        
        
    }
    
    public virtual void Move()
    {
        Vector3 tempPos = pos; //current position
        tempPos.y -= speed*Time.deltaTime; 
        pos=tempPos;
        //pos =Vector3.Lerp(pos, target, speed*Time.deltaTime);
        //target = Hero.S.pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        if(otherGO.tag == "ProjectileHero")
        {
            Destroy(otherGO);
            Destroy(gameObject);
        } else
        {
            print("enemy hit by non projectileHero " +otherGO.name);
        }
    }/*
    private void OnTriggerEnter(Collider other)
    {
        if(engaged==true)return; //aviding threat
         //already know of player
        if(other.gameObject.CompareTag("Hero"))
        {
            
            target = Hero.S.pos;
        }
    }
    private void ChooseDirection()
    {
        if(engaged||inRange)
        {
            return;
        }
        float xp = Random.Range(0,1);
        float yp = Random.Range(0, 1);
        
        Vector3 temp = new Vector3
        print(temp);
        temp.z=0;
        target = temp;
        Invoke("ChooseDirection", 2f);
    }*/
}
