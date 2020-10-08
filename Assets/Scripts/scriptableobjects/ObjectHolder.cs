using ships.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "container", fileName = "containerObject")]
public class ObjectHolder: ScriptableObject
    {
        public  List<Ship_Stats> Ship_Stats;
        public  List<VoidEvent> Void_Events;
        public List<Vector3Event> Vector3_Events;
    }

