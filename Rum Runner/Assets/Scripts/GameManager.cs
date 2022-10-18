using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float finalTime;
    public static int finalRumBottles;

    private static float timer;
    [SerializeField] GameObject exit;
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;

    public int levelScore;
    public static int rumBottles = 0;
    public static bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        isPaused = false;
        exit.SetActive(false);
        timer = 0;
        rumBottles = levelScore;
    }
    private void Start()
    {
        levelScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            timer += Time.deltaTime;
            timeText.text = ("Time: " + timer.ToString("F2") + "s");
            scoreText.text = ("Bottles Collected: " + rumBottles.ToString());

            if(rumBottles >= 3)
            {
                exit.SetActive(true);
            }
        }
    }


    public static void Die()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public static void Pause()
    {
        isPaused = !isPaused;
        Debug.Log("PAUSED");
    }

    public static void Win()
    {
        finalTime = timer;
        finalRumBottles = rumBottles;
        SceneManager.LoadScene("WinScreen");
    }
}