using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Schedules : MonoBehaviour
{
    public enum ClassState
    {
        OnTime, Late, VeryLate
    }

    public enum ArriveState
    {
        Early, OnTime
    }

    public enum LunchState
    {
        Outside, Caf, Pool, Hallway1, Hallway2, Hallway3
    }
    public enum LunchState2
    {
        Outside, Caf, Pool, Hallway1, Hallway2, Hallway3, Library, Other
    }

    public enum HomeState
    {
        OnTime, Late, VeryLate
    }
    [SerializeField] private TimeCycle tc;
    

    [SerializeField] private ClassState cs;
    [SerializeField] private ArriveState a;
    [SerializeField] private LunchState ls;
    [SerializeField] private LunchState2 ls2;
    [SerializeField] private HomeState hs;

    public void EventReceptor(int eventIndex)
    {
        switch (eventIndex)
        {
            case 0:
                switch (cs)
                {
                    case ClassState.OnTime:
                Action(8, 0, "Classroom");
                        break;
                    case ClassState.Late:
                        Action(8, 10, "Classroom");
                        break;
                    case ClassState.VeryLate:
                        Action(8, 30, "Classroom");
                        break;
                }
                break;
            case 1:
                switch (ls)
                {
                    case LunchState.Outside:
                        Action(13, 0, "Outside");
                        break;
                    case LunchState.Caf:
                        Action(13, 0, "Cafeteria");
                        break;
            
                }
                break;

            case 2:
                switch (ls2)
                {
                    case LunchState2.Outside:
                        Action(13, 30, "Outside");
                        break;
                    case LunchState2.Caf:
                        Action(13, 30, "Cafeteria");
                        break;
                    case LunchState2.Hallway1:
                        Action(13, 30, "SampleScene");
                        break;
                    case LunchState2.Hallway2:
                        Action(13, 30, "Upstairs Hallway");
                        break;
                    case LunchState2.Hallway3:
                        Action(13, 30, "Third Floor Hallway");
                        break;
                    case LunchState2.Library:
                        Action(13, 30, "Library");
                        break;
                    case LunchState2.Other:
                        Action(13, 30, "");
                        break;

                }
                break;
            case 3:
                switch (a)
                {
                    case ArriveState.OnTime:
                        Action(7, 30, "Gates");
                        break;
                    case ArriveState.Early:
                        Action(7, 0, "Gates");
                        break;
                    
                }
                break;
            case 4:
                switch (hs)
                {
                    case HomeState.OnTime:
                        Action(16, 0, "");
                        break;
                    case HomeState.Late:
                        Action(16, 30, "");
                        break;
                    case HomeState.VeryLate:
                        Action(17, 0, "");
                        break;
                }
                break;
        }
    }

    public void Action(int hours, int minutes, string location)
    {
        if (hours == tc.hours && minutes == tc.minutes)
        {
            if (SceneManager.GetActiveScene().name == location)
            {

                gameObject.SetActive(true);
                Color32 tempColour = GetComponent<SpriteRenderer>().color;
                Color32 endColour = GetComponent<SpriteRenderer>().color;
                endColour.a = 255;
                tempColour = Color32.Lerp(GetComponent<SpriteRenderer>().color, endColour, Time.time);
                GetComponent<SpriteRenderer>().color = tempColour;
            }
            else

            {
                Color32 tempColour = GetComponent<SpriteRenderer>().color;
                Color32 endColour = GetComponent<SpriteRenderer>().color;
                endColour.a = 0;
                tempColour = Color32.Lerp(GetComponent<SpriteRenderer>().color, endColour, Time.time);
                GetComponent<SpriteRenderer>().color = tempColour;
                if (GetComponent<SpriteRenderer>().color.a == 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
