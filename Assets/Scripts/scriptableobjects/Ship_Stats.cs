using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "stats/base", fileName = "Ship_Stats")]
public class Ship_Stats : ScriptableObject
{
   //responsible for readonly movements and unchanged stats. 
    
    public float rollMult;
    public float pitchMult;
    public GameObject projectilePrefab;

    [Header("shared attributes")]
    public float fireRate;
    public float speed;
    public float health;
    public float powerUpDropChance;
    public int score;
}
