using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionsSceneManager : MonoBehaviour
{

    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void Play()
    {
        SceneManager.LoadScene("Level 1-1");
    }
}
