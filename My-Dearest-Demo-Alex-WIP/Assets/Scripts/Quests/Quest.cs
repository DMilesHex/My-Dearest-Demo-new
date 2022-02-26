using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

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
    public UnityEvent startQuest;
    
    public static bool OnQuest;
    public UnityEvent complete;
    

    private void OnEnable()
    {
        CompleteQuest.OnQuestCompleted += QuestCompleted;
    }

    public void Init()
    {
        
        

        if (!OnQuest)
        {
            
            QuestStarted();
        }
        else
            Debug.Log("You have already started a quest");
    }


    public void QuestStarted()
    {
        Debug.Log("Please work");
        OnQuest = quest switch
        {


            Quests.Habiki => true,
            Quests.Kazou => true,
            Quests.Rin => true,
            Quests.Minori => true,
            _ => false,
        };
    }

    public void QuestCompleted()
    {
    if (OnQuest)
    {
        complete.Invoke();
        OnQuest = false;
        Destroy(this);
    }
    }
}
