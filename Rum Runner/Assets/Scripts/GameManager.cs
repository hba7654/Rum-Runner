using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float finalTime;
    public static float fastestTime;
    public static int finalRumBottles;

    private static float timer;
    [SerializeField] GameObject exit;
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;
    [SerializeField] Text fastestTimeText;


    public int levelScore;
    public static int rumBottles = 0;
    public static bool isPaused;
    // Start is called before the first frame update
    public GameObject pauseScreen;




    void Awake()
    {
        isPaused = true;
        exit.SetActive(false);
        timer = 0;
        rumBottles = levelScore;
    }
    private void Start()
    {
        levelScore = 0;
        PlayerPrefs.GetFloat("fastestTime", 100.0f);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetFloat("fastestTime"));


        fastestTimeText.text = ("Fastest Time: " + PlayerPrefs.GetFloat("fastestTime").ToString("F2") + "s");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("fastestTime"));
        Debug.Log(PlayerPrefs.HasKey("fastestTime"));
        if (!isPaused)
        {
            timer += Time.deltaTime;
            timeText.text = ("Time: " + timer.ToString("F2") + "s");
            scoreText.text = ("# Rum Bottles: " + rumBottles.ToString());

            if(rumBottles >= 3)
            {
                exit.SetActive(true);
            }
        }
        pauseScreen.SetActive(isPaused);

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
        Debug.Log(finalTime);
        finalRumBottles = rumBottles;


        if (finalTime <= PlayerPrefs.GetFloat("fastestTime") )
        {
            PlayerPrefs.SetFloat("fastestTime", fastestTime);
            PlayerPrefs.Save();
            //fastestTime = PlayerPrefs.GetFloat("fastestTime");
        }

        SceneManager.LoadScene("WinScreen");


    }
}
