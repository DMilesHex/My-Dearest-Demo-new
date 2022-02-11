using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NonDialogueInteractions : MonoBehaviour
{
    List<GameObject> collisions;
    
    bool giftGiving;
    public UnityEvent startDialogue, removeGift, removeWeapon;
    public player pl;
    public bool met;
    public Weapon knife;
    public Animator an;

    private void Start()
    {
        collisions = new List<GameObject>();
    }

    public void MetStudent()
    {
        met = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (!collisions.Contains(collision.gameObject))
            collisions.Add(collision.gameObject);
        if (collision.CompareTag("gift") && met)
        {
            Debug.Log("test");
            giftGiving = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.name == "Player" 
            && Input.GetKeyDown(KeyCode.F) && knife.equipped)
        {
            an.SetBool("Bloody", true);
            Debug.Log("dead");
            pl.Sanity -= 10;
            removeWeapon.Invoke();
            Destroy(gameObject);

        }
        if (giftGiving && Input.GetAxis("Jump") > 0)
        {
            
            startDialogue.Invoke();
            removeGift.Invoke();

        }

    }
}
