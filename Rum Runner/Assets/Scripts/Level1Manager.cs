using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public static float finalTime;
    public static float fastestTime;
    public static int finalRumBottles;

    //These keep track of GameManger's total scores/times so they're not overwritten if player wants to replay level
    private float startingTime;
    private float startingFastestTime;
    private int startingScore;

    [SerializeField] GameObject exit;
    [SerializeField] private int requiredScore;

    public int levelScore;
    // Start is called before the first frame update
    void Start()
    {
        levelScore = 0;
        exit.SetActive(false);
        GameManager.level = 1;
        if (!PlayerPrefs.HasKey("level1HighScore")) {
            PlayerPrefs.SetFloat("level1HighScore", 1000);
        }
        
        Debug.Log("stored score" + PlayerPrefs.GetFloat("level1HighScore"));
        fastestTime = PlayerPrefs.GetFloat("level1HighScore");



        startingTime = GameManager.totalTime;
        startingFastestTime = GameManager.totalFastestTime;
        startingScore = GameManager.totalRumBottles;
        GameManager.requiredScore = requiredScore;

        GameManager.totalFastestTime = fastestTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.rumBottles >= requiredScore)
        {
            exit.SetActive(true);
        }
    }

    public static void Die()
    {
        SceneManager.LoadScene("Level 1-1");
    }

    public static void Win()
    {
        finalTime = GameManager.timer;
        finalRumBottles = GameManager.rumBottles;



        if (finalTime <= fastestTime)
        {
            fastestTime = finalTime;
            PlayerPrefs.SetFloat("level1HighScore", fastestTime);
            Debug.Log("updated score" + PlayerPrefs.GetFloat("level1HighScore"));
        }

        SceneManager.LoadScene("WinScreen");


    }
    public static void Nextlevel()
    {

        GameManager.totalTime += finalTime;
        GameManager.totalFastestTime += fastestTime;
        GameManager.totalRumBottles += finalRumBottles;

        SceneManager.LoadScene("Level 2");
    }
}
