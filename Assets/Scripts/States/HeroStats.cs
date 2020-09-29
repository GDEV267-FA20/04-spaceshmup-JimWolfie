using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroStats", menuName = "Stats")]
public class HeroStats : ScriptableObject
{

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    //variable prjectiles idk man
    public GameObject projectilePrefab;
    public float projectileSpeed = 40f;
    public float radius = 1;
}
