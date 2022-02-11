using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Attach those components:")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Selectable continueButton;
    [Space(5)]
    [Header("Scenes name")]
    [SerializeField] private string startScene;
    [SerializeField] private string continueScene;

    private SaveData saveData;

    private void Start()
    {
        saveData = SaveSystem.Load();
        Interactable();
    }

    /// <summary> Set the audio volume </summary>
    public void SetVolume(float volume)
    {
        saveData.Volume = volume;
        audioMixer.SetFloat("volume", volume);
        SaveSystem.Save(saveData);
    }

    /// <summary> Set the quality of the game </summary>
    public void SetQuality(int qualityIndex)
    {
        saveData.Quality = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
        SaveSystem.Save(saveData);
    }


    /// <summary> Set the full screen </summary>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    /// <summary> Start the game. Start the scene based on startScene string </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }


    /// <summary> Continue the game, scene loaded based on continuescene string </summary>
    public void ContinueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    /// <summary> Enable settings menu and disable main menu </summary>
    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    /// <summary> Go to the main menu </summary>
    public void GoBack()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }


    /// <summary> Is the load menu interactable? </summary>
    private void Interactable()
    {
        if (saveData.Day == 0)
        {
            continueButton.interactable = false;
            continueButton.GetComponentInChildren<Image>().color = new Color(1, 1, 1, .5f);
        }
        else if (saveData.Day >= 1)
        {
            continueButton.interactable = true;
            continueButton.GetComponentInChildren<Image>().color = Color.white;
        }
    }
}
