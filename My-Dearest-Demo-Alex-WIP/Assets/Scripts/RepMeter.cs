using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepMeter : MonoBehaviour
{
    public void ChangeRep(int rep)
    {
        transform.position = new Vector3(transform.position.x + rep, transform.position.y);
    }
}
