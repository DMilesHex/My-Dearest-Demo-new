using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Rival", menuName = "RivalInfo"), Serializable]
public class RivalInfo : ScriptableObject
{
    [SerializeField] private int pop;
    [SerializeField] private Sprite portrait;
    [SerializeField] private NpcName npcName;
    [SerializeField] [TextArea(3, 10)] private string _infoText;

    public string InfoText { get => _infoText; set => _infoText = value; }
    public Sprite Portrait { get => portrait; set => portrait = value; }
    public int Pop { get => pop; set => pop = value; }
    public NpcName NpcName { get => npcName; set => npcName = value; }
}
