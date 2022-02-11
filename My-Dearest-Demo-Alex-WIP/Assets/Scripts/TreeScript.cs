using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{    
    [SerializeField] private player player;
    private List<GameObject> collisions;

    private void Awake()
    {
        collisions = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collisions.Contains(collision.gameObject))
            collisions.Add(collision.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collisions[0] != null && player.chopped)
        {
            Debug.Log("stuff");
            player.Sanity -= 40;
            Destroy(collisions[0].gameObject);
        }
    }
}
