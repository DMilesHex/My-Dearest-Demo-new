using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;   
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private RepMeter rm;
    [SerializeField] private player player;
    [SerializeField] private Image portrait;
    [SerializeField] private GameObject portraitContainer;
    public List<DialogueActivator> dialogueActivator;


    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;

    public bool IsOpen { get; private set; }

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject, int index)
    {
        
        IsOpen = true;
        dialogueBox.SetActive(true);
        ClubRep(index);
        StartCoroutine(StepThroughDialogue(dialogueObject, index));
    }

    
    public void ClubRep(int index)
    {
        dialogueActivator[index].Rep += 5;


    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject, int index)
    {
        if (player.canGainRep && dialogueObject.RepFactor != 0)
        {
            dialogueActivator[index].Rep += dialogueObject.RepFactor + player.repIncrease;
            rm.ChangeRep(dialogueActivator[index].Rep);
        }
        if (dialogueObject.Target != null)
            dialogueObject.Target.Pop += dialogueObject.StudentPop;

        for (int i = 0; i < dialogueObject.DialogueLines.Count; i++)
        {
            
            DialogueLine dialogue = dialogueObject.DialogueLines[i];
            nameText.text = dialogue.NpcName.ToString();
            if (dialogue.Portrait != null)
            {
                portraitContainer.SetActive(true);
                portrait.sprite = dialogue.Portrait;
            }
            else
            {
                
                portraitContainer.SetActive(false);
            }
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.DialogueLines.Count - 1 && dialogueObject.HasResponses) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            
        }
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses, index);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
