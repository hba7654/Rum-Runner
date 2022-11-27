using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingScreenManager : MonoBehaviour
{
    public void ClearHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void Play()
    {
        SceneManager.LoadScene("Level 1-1");
    }
}
