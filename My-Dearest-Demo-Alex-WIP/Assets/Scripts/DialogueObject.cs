using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RenameMe", menuName = "DialogueTest/DialogueLine"), Serializable]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private int repFactor;
    [SerializeField] private int studentPop;
    [SerializeField] private DialogueActivator target;
    [SerializeField] private List<DialogueLine> _dialogueLine;
    public List<DialogueLine> DialogueLines
    {
        get => _dialogueLine;
        set => _dialogueLine = value;
    }

    [SerializeField] private Response[] responses;

    public Response[] Responses => responses;
    public bool HasResponses => Responses != null && Responses.Length > 0;
    public int RepFactor => repFactor;
    public int StudentPop => studentPop;
    public DialogueActivator Target => target;
}
