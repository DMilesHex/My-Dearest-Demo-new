using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;
    public Sprite knifeSprite;
    public Sprite axeSprite;
    public Sprite hummingBirdSprite;
    public Sprite oishiOishiSprite;
    public Sprite fidgetCubeSprite;
}
