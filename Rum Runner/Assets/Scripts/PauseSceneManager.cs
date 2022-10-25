using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSceneManager : MonoBehaviour
{
    public GameObject gameManager;

    public void Resume()
    {
        GameManager.isPaused = false;
        Debug.Log("Resume");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
