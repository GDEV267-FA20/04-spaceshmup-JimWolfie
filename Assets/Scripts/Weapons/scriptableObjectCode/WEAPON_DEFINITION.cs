using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weaponDEfs", menuName = "lists and dictionaries")]
public class WEAPON_DEFINITION : ScriptableObject
{
    public WEAPON_ABSTRACT[] weapon_list;
    public Dictionary<WeaponType, WEAPON_ABSTRACT> wDictonary;
    public void OnEnable()
    {
        if(weapon_list == null)
        {
            Debug.Log("cry and complain on unity forums about how scriptable objects are stupid and that you're stupid");
            
        }else
        {
            if(wDictonary == null)
            {
                wDictonary = new Dictionary<WeaponType, WEAPON_ABSTRACT>();
            }
            foreach(WEAPON_ABSTRACT wp in weapon_list)
            {
                var _type = wp.type;
                wDictonary[wp.type] = wp;
            }
        }
    }
    public WEAPON_ABSTRACT GetWeaponDefinition(WeaponType wt)
    {
        if(wDictonary.ContainsKey(wt))
        {
            return (wDictonary[wt]);
            
        }
        Debug.Log("oops");
        return(weapon_list[0]); 
    }
    
}

