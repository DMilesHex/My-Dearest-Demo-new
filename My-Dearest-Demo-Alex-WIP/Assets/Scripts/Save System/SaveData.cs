using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    /// <summary>The number of money player has available</summary>
    public float Money;
    /// <summary>The day player ended in.</summary>
    public int Day;
    /// <summary>The week player ended in.</summary>
    public int Week;
    /// <summary>The graphics quality.</summary>
    public int Quality;
    /// <summary>The volume.</summary>
    public float Volume;
    /// <summary>ID's of the active weapons.</summary>
    public List<int> WeaponsID;

    /// <summary>Creates a brand new, empty save file.</summary>
    public SaveData()
    {
        Money = 0;
        Day = 0;
        Week = 0;
        Quality = 0;
        Volume = 0;
    }

    /// <summary>Creates a save file from the given save information</summary>
    /// <param name="savedMoney">The amount of money which was saved.</param>
    /// <param name="saveDay">The amount of saved days.</param>
    /// <param name="savedWeek">The amount of saved week.</param>
    /// <param name="savedDay">The amount of saved days. </param>
    /// <param name="savedQuality">The quality of graphic which was saved.</param>
    /// <param name="savedVolume">The saved volume from settings.</param>
    public SaveData(float savedMoney, int savedDay, int savedWeek, int savedQuality, int savedVolume, List<int> savedIDs)
    {
        Money = savedMoney;
        Day = savedDay;
        Week = savedWeek;
        Quality = savedQuality;
        Volume = savedVolume;
        WeaponsID = savedIDs;
    }
}
