using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueActivator : MonoBehaviour, I_Interactable
{
    [SerializeField] private DialogueObject dialogueObject;
    public int Rep;
    public int Pop;
    

    [SerializeField] private RectTransform canvas, buttonPrompt;
    [SerializeField] private GameObject promptPrefab;
    [SerializeField] private int studentIndex;
    
    public void UpdateDialogueObject(DialogueObject dialogueObject) => this.dialogueObject = dialogueObject;
    public void Interact(player pl)
    {
        DialogueResponseEvents dialogue = GetComponent<DialogueResponseEvents>();
        ResponseEvent[] responseEvents = dialogue.Events;
            if (dialogue)
            {
                Debug.Log(responseEvents.Length);
                pl.DialogueUI.AddResponseEvents(responseEvents);
            }
        
        pl.DialogueUI.ShowDialogue(dialogueObject, studentIndex);
        Debug.Log(gameObject.name);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            player pl = collision.GetComponent<player>();
            pl.interactable = this;
            promptPrefab =  Instantiate(buttonPrompt.gameObject, canvas);
            Text[] texts = promptPrefab.GetComponentsInChildren<Text>();
            texts[0].text = "E";
            texts[1].text = "Talk";
            promptPrefab.transform.position = gameObject.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player pl = collision.GetComponent<player>();

            if (pl.interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
                pl.interactable = null;

            Destroy(promptPrefab);
        }
    }
}
