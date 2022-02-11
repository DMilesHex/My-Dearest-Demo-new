using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class House : MonoBehaviour
{
    [SerializeField] private List<DialogueObject> dialogue;
    [SerializeField] private TMP_Text infoText;
    
    public void ShowText(int index)
    {
        for(int i = 0; i < dialogue[index].DialogueLines.Count; i++)
            infoText.text = dialogue[index].DialogueLines[i].LineText; 
    }
    public void HideText()
    {
        infoText.text = string.Empty;
    }
}
