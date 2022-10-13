using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;
    private void Update()
    {
        timeText.text = ("Time: " + GameManager.finalTime.ToString("F2") + "s");
        scoreText.text = ("Bottles Collected: " + GameManager.finalRumBottles.ToString());
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Level 1-1");
    }
}
