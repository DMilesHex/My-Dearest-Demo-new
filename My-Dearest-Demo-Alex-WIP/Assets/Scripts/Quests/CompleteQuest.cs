using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuest : MonoBehaviour
{
    public delegate void QuestCompleted();
    public static event QuestCompleted OnQuestCompleted;
    [Header("Name of the rival")]
    [SerializeField] private Quests questName;
    [SerializeField] private DialogueActivator dialogueActivator;

    public void Complete(int repIncrease)
    {
        dialogueActivator.Rep += repIncrease;
    }
}
