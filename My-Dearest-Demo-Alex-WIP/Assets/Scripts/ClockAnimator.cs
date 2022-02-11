using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockAnimator : MonoBehaviour
{
    [SerializeField] private Transform hourHand, minuteHand;
    [SerializeField] private TimeCycle time;

    private void Update()
    {
        hourHand.eulerAngles = new Vector3(0, 0, -time.hours * (360/12));
        minuteHand.eulerAngles = new Vector3(0, 0, -time.minutes * (360/60));
    }
}
