using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Weapon,
    Item
}

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private ItemTypes type;
    private Transform player;

    void Start()
    {
        if (player != null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        else
            player = null;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x + 4, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
