using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuest : MonoBehaviour
{
    public delegate void QuestCompleted();
    public static event QuestCompleted OnQuestCompleted;
    [Header("Name of the rival")]
    [SerializeField] private Quests questName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            OnQuestCompleted();
    }
}
