using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSceneManager : MonoBehaviour
{
    [SerializeField] Button resumeBttn;
    [SerializeField] Button resetBttn;
    [SerializeField] Button quitBttn;

    private void Update()
    {
        resumeBttn.onClick.AddListener(Resume);
/*        if (resumeBttn.onClick)
        {
            GameManager.isPaused = false;
            Debug.Log("Testing Resume");
        }
*/
    }

    public void Resume()
    {

        GameManager.isPaused = false;
        Debug.Log("Resume");

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
