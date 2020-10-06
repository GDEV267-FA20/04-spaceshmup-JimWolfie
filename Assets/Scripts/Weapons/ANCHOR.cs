using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ANCHOR", menuName = "anchor")]
public class ANCHOR : ScriptableObject
{
    public BULLET_ORIENT bt;
    public GameObject PROJECTILE_ANCHOR;
    
    private void OnEnable()
    {
        if(PROJECTILE_ANCHOR == null)
        {
            
            var sus = bt.go;
            PROJECTILE_ANCHOR = sus;
        }
    }
}
