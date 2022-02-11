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
    [SerializeField] private Quests quests;
    [SerializeField] float points; //I forgot what should be given after the task is done. Just change it to the name that is better for you.

    [Header("Info about the quest")]
    [SerializeField] private string questInfo;
    [SerializeField] private TextMeshProUGUI questUIText;


    public static bool OnQuest;

    private void Awake()
    {
        questUIText.text = questInfo;

        if (!OnQuest)
            QuestStarted();
        else
            Debug.Log("You have already selected a quest");
    }


    private void QuestStarted()
    {
        OnQuest = quests switch
        {
            Quests.Habiki => true,
            Quests.Kazou => true,
            Quests.Rin => true,
            Quests.Minori => true,
            _ => false,
        };
    }
}
