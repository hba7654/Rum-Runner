using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float totalTime;
    public static float totalFastestTime;
    public static int totalRumBottles;
    public static int rumBottles = 0;
    public static int requiredScore = 0;

    public static int level;

    public static float timer;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text fastestTimeText;


    public static bool isPaused;
    public static bool hasStarted;
    public GameObject pauseScreen;


    void Awake()
    {
        isPaused = false;
        hasStarted = false;
        timer = 0;
        rumBottles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fastestTimeText.text = ("Fastest Time: " + totalFastestTime.ToString("F2") + "s");
        if (!isPaused && hasStarted)
        {
            timer += Time.deltaTime;
            timeText.text = ("Time: " + timer.ToString("F2") + "s");
            scoreText.text = ("<sprite=0>x" + rumBottles.ToString() + "/" + requiredScore.ToString());

        }
        pauseScreen.SetActive(isPaused);

    }

    public static void Pause()
    {
        isPaused = !isPaused;
        Debug.Log("PAUSED");
    }

    public static void Win()
    {
        switch(level)
        {
            case 1:
                Level1Manager.Win();
                break;
            case 2:
                Level2Manager.Win();
                break ;
            case 3:
                Level3Manager.Win();
                break;
        }
    }

    public static void Die()
    {
        switch (level)
        {
            case 1:
                Level1Manager.Die();
                break;
            case 2:
                Level2Manager.Die();
                break;
            case 3:
                Level3Manager.Die();
                break;
        }
    }
}
