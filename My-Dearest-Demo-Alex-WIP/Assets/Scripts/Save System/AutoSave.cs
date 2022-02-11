using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    [Header("How often should the autosave save the game")]
    [SerializeField] private float timeBeforeSave;
    [Space(2)]
    [Header("Scripts that are saved:")]
    [SerializeField] private Money money;
    [SerializeField] private TimeCycle timeCycle;

    private SaveData saveData;
    private float time;

    private void Awake() => saveData = SaveSystem.Load();
       
    void Update() => CalculateTime();

    /// <summary> Calculate the time and save the data when it's time to save them.</summary>
    private void CalculateTime()
    {
        if (time < timeBeforeSave)
        {
            time += Time.deltaTime;
        }
        else 
        {
            Save();
            print("saved");
            time = 0;
        }        
    }

    /// <summary> Save the data </summary>
    public void Save()
    {
        saveData.Money = money.MoneyAmount;
        saveData.Day = timeCycle.Day;
        saveData.Week = timeCycle.Week;

        SaveSystem.Save(saveData);
    }
}
