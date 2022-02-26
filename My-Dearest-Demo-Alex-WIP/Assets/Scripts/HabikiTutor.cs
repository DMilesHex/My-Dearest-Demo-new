using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HabikiTutor : MonoBehaviour
{
    [SerializeField] private DialogueUI ui;
    [SerializeField] private bool tutorQuestDone;
    [SerializeField] private DialogueActivator dialogueActivator;
    [SerializeField] private GameObject tutorButtons;
    [SerializeField] private UnityEvent complete;

    public void RightAnswers()
    {
        complete.Invoke();

        tutorButtons.SetActive(false);
    }

    public void WrongAnswers()
    {
        tutorQuestDone = true;
        dialogueActivator.Pop -= 5;
        tutorButtons.SetActive(false);
    }
}
