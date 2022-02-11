using System;
using UnityEngine;

public enum NpcName
{
    Manami, Habiki, Ryo, Narration, Rin, Kyoko, Minori, Kazou //...
}

[Serializable]
public class DialogueLine
{
    [SerializeField] private NpcName npcName;
    [SerializeField] private Sprite portrait;

    [SerializeField] [TextArea(3, 10)] private string _lineText;

    public string LineText { get => _lineText; set => _lineText = value; }
    public NpcName NpcName { get => npcName; set => npcName = value; }
    public Sprite Portrait { get => portrait; set => portrait = value; }
}
