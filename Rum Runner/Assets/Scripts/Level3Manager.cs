using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
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
        GameManager.level = 3;

        startingTime = GameManager.totalTime;
        startingFastestTime = GameManager.totalFastestTime;
        startingScore = GameManager.totalRumBottles;
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
        SceneManager.LoadScene("Level 3");
    }

    public static void Win()
    {
        finalTime = GameManager.timer;
        finalRumBottles = GameManager.rumBottles;



        if (finalTime <= fastestTime)
        {
            fastestTime = finalTime;
        }

        SceneManager.LoadScene("WinScreen");


    }
    public static void Nextlevel()
    {

        GameManager.totalTime += finalTime;
        GameManager.totalFastestTime += fastestTime;
        GameManager.totalRumBottles += finalRumBottles;

        SceneManager.LoadScene("TitleScreen");
    }
}
