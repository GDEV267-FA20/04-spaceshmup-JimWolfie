using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponDEfs", menuName = "lists and dictionaries")]
public class WEAPON_DEFINITION : ScriptableObject
{
    public string letter;
    public bool tag;
    public Color color;
    public GameObject projectilePrefab;
    public Color projectileColor;
    public float damageOnHit = 0;
    public float continuousDamage = 0;
    public float delayBetweenShots;
    public float vel;
}

