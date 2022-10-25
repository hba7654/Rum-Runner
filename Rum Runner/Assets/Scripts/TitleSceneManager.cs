using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("InstructionsScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
