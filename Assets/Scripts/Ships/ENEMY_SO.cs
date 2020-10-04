using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ENEMY_SO", menuName = "ShipBehavior")]
public class ENEMY_SO : ScriptableObject
{
    
    public float speed = 10f;
    public float fireRate = .3f;
    public float health = 10f;
    public int score = 100;
    public float showDamageDuration = 0.1f;
    public float powerUpDropChance = 1f;

   
}
