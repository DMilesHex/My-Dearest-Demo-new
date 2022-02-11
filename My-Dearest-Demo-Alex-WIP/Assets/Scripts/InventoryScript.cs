using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private player player;
    [SerializeField] private List<Weapon> inventoryList = new List<Weapon>();
    [SerializeField] private List<GameObject> weaponSprites;
    [SerializeField] private NonDialogueInteractions student;
    [SerializeField] private List<Pickup> pickup;

    public List<Weapon> InventoryList { get => inventoryList; set => inventoryList = value; }

    private SaveData saveData;
    private void Awake()
    {
        saveData = SaveSystem.Load();
    }

    public void Remove(int index)
    {
       RemoveItem(InventoryList[index], index);
       pickup[index].DisableButton();
    }

    public void OnClickButton(Weapon equippedWeapon)
    {
        
        foreach (Weapon weapon in InventoryList)
        {
            weapon.equipped = false;
        }

        equippedWeapon.equipped = true;

        if (equippedWeapon.nameString == "Wood Hatchet")
        {
            Debug.Log("Axe in hand");
            weaponSprites[1].SetActive(true);
        }
        else if (equippedWeapon.nameString == "Fidget Cube")
        {
            if (player.Sanity <= player.SanityMax - 10)
                player.Sanity += 10;
            equippedWeapon.equipped = false;
            Debug.Log(player.Sanity);
        }
        else if (equippedWeapon.nameString == "Hunting Knife")
        {
            Debug.Log("Knife in hand");
            weaponSprites[0].SetActive(true);
        }
        else if (equippedWeapon.nameString == "Humming Bird Charm")
        {
            Debug.Log("charm in hand");
            weaponSprites[2].SetActive(true);
        }
    }

    public void AddWeapon(Weapon weapontoadd)
    {
        InventoryList.Add(weapontoadd);
        weapontoadd.equipped = true;
    }

    public void RemoveItem(Weapon itemToRemove, int itemIndex)
    {
        if (GameObject.Find(itemToRemove.weaponprefab.name))
        {
            Debug.Log("deleted");
            saveData.WeaponsID.Remove(itemToRemove.ID);
            InventoryList.Remove(itemToRemove);
            SaveSystem.Save(saveData);
        }
        weaponSprites[itemIndex].SetActive(false);
    }
}
