﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform  responseButtonTemplate, responseContainer;
    private GameObject buttonText;
    private DialogueUI dialogueUI;
    List<GameObject> tempResponseButtons = new List<GameObject>();
    private ResponseEvent[] responseEvents;
    public DialogueActivator dialogueActivator;

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
        
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        this.responseEvents = responseEvents;
    }

    public void ShowResponses(Response[] responses, int studentIndex)
    {
        
        for(int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponentInChildren<Text>().text = response.ResponseText;
            
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex, studentIndex));

            tempResponseButtons.Add(responseButton);
            
        }

        
    }

    private void OnPickedResponse(Response response, int responseIndex, int studentIndex)
    {
        responseContainer.gameObject.SetActive(false);
        

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }

        

        if (responseEvents != null && responseIndex < responseEvents.Length)
        {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        responseEvents = null;
        tempResponseButtons.Clear();

        if (response.DialogueObject)
        {
            dialogueUI.ShowDialogue(response.DialogueObject, studentIndex);
            responseContainer.gameObject.SetActive(true);
        }
        else
            dialogueUI.CloseDialogueBox();
    }
}