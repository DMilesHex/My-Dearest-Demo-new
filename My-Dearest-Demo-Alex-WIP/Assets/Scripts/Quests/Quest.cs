using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Quests
{
    Habiki, Kazou, Rin, Minori
}

public class Quest : MonoBehaviour
{
    [Header("Select a quest")]
    [SerializeField] private Quests quest;
    [SerializeField] float rep; 

    [Header("Info about the quest")]
    [SerializeField] private string questInfo;
    [SerializeField] private TextMeshProUGUI questUIText;

    public static bool OnQuest;

    private void OnEnable()
    {
        CompleteQuest.OnQuestCompleted += QuestCompleted;
    }

    private void Awake()
    {
        questUIText.text = questInfo;

        if (!OnQuest)
            QuestStarted();
        else
            Debug.Log("You have already started a quest");
    }


    private void QuestStarted()
    {
        OnQuest = quest switch
        {
            Quests.Habiki => true,
            Quests.Kazou => true,
            Quests.Rin => true,
            Quests.Minori => true,
            _ => false,
        };
    }

    private void QuestCompleted()
    {
        OnQuest = false;
        Destroy(this);
    }
}
