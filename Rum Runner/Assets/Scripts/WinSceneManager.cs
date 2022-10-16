using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;
    [SerializeField] Text fastestTimeText;

    private void Update()
    {
        timeText.text = ("Time: " + GameManager.finalTime.ToString("F2") + "s");
        scoreText.text = ("# Rum Bottles: " + GameManager.finalRumBottles.ToString());
        fastestTimeText.text = ("Fastest Time: " + GameManager.fastestTime.ToString("F2") + "s");
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
