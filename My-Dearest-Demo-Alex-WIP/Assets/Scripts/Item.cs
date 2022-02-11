using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Knife,
        Axe,
        HummingBirdCharm,
        OishiOishi,
        FidgetCube,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Knife:                return ItemAssets.Instance.knifeSprite;
            case ItemType.Axe:                  return ItemAssets.Instance.axeSprite;
            case ItemType.HummingBirdCharm:     return ItemAssets.Instance.hummingBirdSprite;
            case ItemType.OishiOishi:           return ItemAssets.Instance.oishiOishiSprite;
            case ItemType.FidgetCube:           return ItemAssets.Instance.fidgetCubeSprite;
        }
    }
}
