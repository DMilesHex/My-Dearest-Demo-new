using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float sov = 5f;
    [SerializeField] private Transform sight;
    [SerializeField] private player playerScript;
    [SerializeField] private int sanityLevel = 60;
    private int weaponCount;
    private int insaneCount;
    private int bloodyCount;
    [SerializeField] private Animator an;
    private bool seen;

    public List<UnityEvent> gameOver;

    void Update()
    {
        RaycastHit2D sightInfo = Physics2D.Raycast(sight.position, sight.right, sov);

        if (sightInfo.collider == true) {
            if (gameObject.tag == "Teacher") {
                if (sightInfo.collider.gameObject.CompareTag("Player") == true) {
                    //Player can be seen
                    Debug.Log("Always watching Mike Wazowski");
                    if (weapon.activeSelf == true) {
                        //Player is carrying a weopon
                        gameOver[0].Invoke();
                    }

                    if (playerScript.Sanity <= sanityLevel) {
                        gameOver[1].Invoke();
                    }
                }
            }
            else if (gameObject.name == "Ryo") {
                if (sightInfo.collider.gameObject.CompareTag("Player") == true) {

                    //Player can be seen
                    Debug.Log("Hey Manami");
                    if (weapon.activeSelf == true) {
                        //Player is carrying a weopon
                        if (weaponCount <= 1 && !seen) {
                            Debug.Log("Mildly concerned");
                            weaponCount++;
                            seen = true;
                        }
                        else if (weaponCount == 2) {
                            Debug.Log("Very concerned");
                            weaponCount++;
                            seen = true;
                        }
                        else {
                            gameOver[0].Invoke();
                        }
                    }

                    if (an.GetBool("Bloody") == true) {
                        //Player is carrying a weopon
                        if (bloodyCount <= 1) {
                            Debug.Log("Mildly concerned");
                            bloodyCount++;
                        }
                        else if (bloodyCount == 2) {
                            Debug.Log("Very concerned");
                            bloodyCount++;
                        }
                        else {
                            gameOver[2].Invoke();
                        }
                    }
                    if (an.GetBool("Bloody") == true && weapon.activeSelf) {
                        gameOver[3].Invoke();
                    }
                    if (playerScript.Sanity <= sanityLevel) {

                        if (weaponCount <= 1) {
                            Debug.Log("What's wrong with you");
                            weaponCount++;
                        }
                        else if (weaponCount == 2) {
                            Debug.Log("Seriously, are you OK");
                            weaponCount++;
                        }
                        else {
                            gameOver[1].Invoke();
                        }
                    }
                }
            }
            else {
                if (sightInfo.collider.gameObject.CompareTag("Player") == true) {
                    //Player can be seen
                    Debug.Log("Player spotted");
                    if (weapon.activeSelf == true) {
                        //Player is carrying a weopon
                        Debug.Log("AAAAAHHHH KNIFE");
                    }

                    if (playerScript.Sanity <= sanityLevel) {
                        Debug.Log("Uh...");
                    }
                    if (an.GetBool("Bloody") == true) {
                        Debug.Log("What happened to you?");
                    }
                }
            }
        }
        else {
            seen = false;
        }
    }


}
