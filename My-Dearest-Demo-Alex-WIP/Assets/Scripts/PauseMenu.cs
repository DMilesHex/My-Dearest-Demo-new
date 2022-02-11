using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [Header("Attach pause menu Canva")]
    [SerializeField] private GameObject pauseMenu;
    [Header("Attach those scripts")]
    [SerializeField] private AutoSave autoSave;
    [SerializeField] private RivalInfo[] rivals;
    [Header("Sections in the pause menu Canva")]
    [SerializeField] private TextMeshProUGUI rivalName;
    [SerializeField] private TextMeshProUGUI personality, points;
    [SerializeField] private Image rivalImg;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        LoadRival();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (pauseMenu.activeSelf) 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        autoSave.Save();
        Application.Quit();
    }

    private void LoadRival()
    {
        rivalImg.sprite = rivals[0].Portrait;
        rivalName.text = rivals[0].NpcName.ToString();
        personality.text = rivals[0].InfoText;
        points.text = $"Pop: {rivals[0].Pop}"; 
    }
}
