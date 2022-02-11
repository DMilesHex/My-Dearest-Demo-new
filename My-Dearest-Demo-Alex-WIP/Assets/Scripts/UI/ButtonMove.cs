using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour
{
    public void HighlightButton(int distance)
    {
        gameObject.transform.Translate(new Vector3(distance, 0));
    }

    public void MoveBack(int distance)
    {
        gameObject.transform.Translate(new Vector3(-distance, 0));
    }
}
