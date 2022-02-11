using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    [SerializeField] private List<GameObject> pointContainers;
    [SerializeField] private GameObject point;

    public void Add(int index)
    {
        Instantiate(point, pointContainers[index].transform);
    }
}
