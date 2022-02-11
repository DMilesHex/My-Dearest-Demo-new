using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabikiTutor : MonoBehaviour
{
    [SerializeField] private DialogueUI ui;
    [SerializeField] private bool tutorQuestDone;
    [SerializeField] private DialogueActivator dialogueActivator;
    [SerializeField] private GameObject tutorButtons;

    public void RightAnswers()
    {
        tutorQuestDone = true;
        tutorButtons.SetActive(false);
    }

    public void WrongAnswers()
    {
        tutorQuestDone = true;
        dialogueActivator.Pop -= 5;
        tutorButtons.SetActive(false);
    }
}
