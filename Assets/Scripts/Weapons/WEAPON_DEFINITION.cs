using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponDEfs", menuName = "lists and dictionaries")]
public class WEAPON_DEFINITION : ScriptableObject
{
    public WEAPON_ABSTRACT[] weapon_list;
    public Dictionary<string, WEAPON_ABSTRACT> wDictonary;
    public void OnEnable()
    {
        if(weapon_list == null)
        {
            Debug.Log("cry and complain on unity forums about how scriptable objects are stupid and that you're stupid");
            
        }else
        {
            if(wDictonary == null)
            {
                wDictonary = new Dictionary<string, WEAPON_ABSTRACT>();
            }
            foreach(WEAPON_ABSTRACT wp in weapon_list)
            {
                var _type = wp.type;
                wDictonary[wp.type] = wp;
            }
        }
    }

}
