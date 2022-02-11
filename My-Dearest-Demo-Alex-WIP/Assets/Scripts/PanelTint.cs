using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTint : MonoBehaviour
{
    [SerializeField] private Image panelColour;
    [SerializeField] private TimeCycle time;

    void Update()
    {       
        if (time.hours >= 16)
        {          
            Color32 tempColour = panelColour.color;
            Color32 endColour = panelColour.color;
            endColour.a = 60;               
            tempColour = Color32.Lerp(panelColour.color, endColour, Time.deltaTime);
            panelColour.color = tempColour;
        }
    }
}
