using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;


public class TimeCycle : MonoBehaviour
{
    public delegate void OnNewWeek();
    public static event OnNewWeek NewWeek; //If it's the new week, call this event.

    private float timePassed;
    public int weeks, days, hours, minutes;
    [Space(2)]
    [SerializeField] private List<UnityEvent> m_event;
    [Space(2)]
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text weekText;

    private SaveData saveData;

    #region Public Variables
    public int Week
    {
        get { return weeks; }
        set { weeks = Week; }
    }

    public int Day
    {
        get { return days; }
        set { days = Day; }
    }
    #endregion

    private void Awake()
    {
        saveData = SaveSystem.Load(); //Load the data and assing dayss and weeks from it.
        days = saveData.Day;
        weeks = saveData.Week;
        weekText.text = "Week " + saveData.Week;
        if (SceneManager.GetActiveScene().name == "Rin's Shop")
        {
            NewWeek();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        timePassed += 1f;

        SetDate();
    }

    public void ClassTime()
    {
        if (hours <= 8)
        {
            hours = 13;
            minutes = 0;
            timePassed = 0;
        }
        else if (hours > 13 && hours < 16)
        {
            hours = 16;
            minutes = 0;
            timePassed = 0;
        }
    }

    private void SetDate()
    {
        if (timePassed == 300)
        {
            timePassed = 0;
            minutes += 10;
        }
        if (minutes == 60)
        {
            minutes = 0;
            hours += 1;
        }
        if (hours == 24)
        {
            hours = 0;
            days += 1;
        }
        if (days == 7)
        {
            days = 0;
            weeks += 1;
            NewWeek();
        }

        if (hours >= 8 && hours < 13 || hours >= 14 && hours < 16)
        {
            m_event[0].Invoke();
        }

        switch (days)
        {
            case 0:
                dayText.text = "Monday";
                break;
            case 1:
                dayText.text = "Tuesday";
                break;
            case 2:
                dayText.text = "Wednesday";
                break;
            case 3:
                dayText.text = "Thursday";
                break;
            case 4:
                dayText.text = "Friday";
                break;
            case 5:
                dayText.text = "Saturday";
                break;
            case 6:
                dayText.text = "Sunday";
                break;
        }

        weekText.text = "Week " + weeks;
    }
}
