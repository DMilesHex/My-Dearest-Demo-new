using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas, UICanvas;

    [SerializeField] private TMP_Text text;

    public void Show(string msg)
    {
        
        gameOverCanvas.SetActive(true);
        UICanvas.SetActive(false);
        text.text = msg;
        StartCoroutine(BackToTitle());
    }

    IEnumerator BackToTitle()
    {
        
        yield return new WaitForSeconds(3f);
        
        PlayerTransporter.LoadMap("[Scene 0] Main Menu");
    }
}
