using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapon")]
public class Weapon : ItemList
{   
    public enum WeaponType
    {
        Knife,
        Axe,
        Blunt//...
    }

    public bool equipped;
    public WeaponType weaponType;
    public GameObject weaponprefab;
    public float price;
}
