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

    private int level;

    private void Start()
    {
        level = GameManager.level;
    }

    private void Update()
    {
        switch(level)
        {
            case 1:
                timeText.text = ("Time: " + Level1Manager.finalTime.ToString("F2") + "s");
                scoreText.text = ("# Rum Bottles: " + Level1Manager.finalRumBottles.ToString());
                fastestTimeText.text = ("Fastest Time: " + Level1Manager.fastestTime.ToString("F2") + "s");
                break;
            case 2:
                timeText.text = ("Time: " + Level2Manager.finalTime.ToString("F2") + "s");
                scoreText.text = ("# Rum Bottles: " + Level2Manager.finalRumBottles.ToString());
                fastestTimeText.text = ("Fastest Time: " + Level2Manager.fastestTime.ToString("F2") + "s");
                break;
            case 3:
                timeText.text = ("Time: " + Level3Manager.finalTime.ToString("F2") + "s");
                scoreText.text = ("# Rum Bottles: " + Level3Manager.finalRumBottles.ToString());
                fastestTimeText.text = ("Fastest Time: " + Level3Manager.fastestTime.ToString("F2") + "s");
                break;
        }
    }
    public void ReloadScene()
    {
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("Level 1-1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
        }
    }

    public void NextLevel()
    {
        switch (level)
        {
            case 1:
                Level1Manager.Nextlevel();
                break;
            case 2:
                Level2Manager.Nextlevel();
                break;
            case 3:
                Level3Manager.Nextlevel();
                break;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
