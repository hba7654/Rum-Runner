using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject mainCanvas;
    public GameObject instrCanvas;
    public GameObject levelsCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;

    [Header("Buttons to Start With")]
    public GameObject mainBtn;
    public GameObject instrBtn;
    public GameObject levelsBtn;
    public GameObject settingsBtn;
    public GameObject creditsBtn; 
    
    [Header("Event System")]
    public EventSystem eventSystem;

    private void Start()
    {
        mainCanvas.SetActive(true);
        instrCanvas.SetActive(false);
        levelsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);

        eventSystem.SetSelectedGameObject(mainBtn);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1-1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Instructions()
    {
        mainCanvas.SetActive(false);
        instrCanvas.SetActive(true);
        levelsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);

        eventSystem.SetSelectedGameObject(instrBtn);
    }

    public void LevelsScreen()
    {
        mainCanvas.SetActive(false);
        instrCanvas.SetActive(false);
        levelsCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);

        eventSystem.SetSelectedGameObject(levelsBtn);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        mainCanvas.SetActive(false);
        instrCanvas.SetActive(false);
        levelsCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        creditsCanvas.SetActive(false);

        eventSystem.SetSelectedGameObject(settingsBtn);
    }

    public void Credits()
    {
        mainCanvas.SetActive(false);
        instrCanvas.SetActive(false);
        levelsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(true);

        eventSystem.SetSelectedGameObject(creditsBtn);
    }

    public void MainMenu()
    {
        mainCanvas.SetActive(true);
        instrCanvas.SetActive(false);
        levelsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        creditsCanvas.SetActive(false);

        eventSystem.SetSelectedGameObject(mainBtn);
    }
    public void ClearHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
