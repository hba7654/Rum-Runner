using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSceneManager : MonoBehaviour
{

    public void Resume()
    {
        //SceneManager.LoadScene("Level 1-1", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level 1-1");
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
