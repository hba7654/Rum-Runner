using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
{
    public  Vector2 startPos;
    public static float finalTime;
    public static float fastestTime;
    public static int finalRumBottles;

    //These keep track of GameManger's total scores/times so they're not overwritten if player wants to replay level
    private float startingTime;
    private float startingFastestTime;
    private int startingScore;

    [SerializeField] PlayerManager player;
    [SerializeField] GameObject exit;
    [SerializeField] private int requiredScore;
    [SerializeField] private GameObject[] bottles;
    //[SerializeField] GameObject grapple;


    public int levelScore;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        startPos = player.transform.position;

        levelScore = 0;
        exit.SetActive(false);
        GameManager.level = 3;

        if (!PlayerPrefs.HasKey("level3HighScore"))
        {
            PlayerPrefs.SetFloat("level3HighScore", 1000);
        }

        Debug.Log("stored score 3 " + PlayerPrefs.GetFloat("level3HighScore"));
        fastestTime = PlayerPrefs.GetFloat("level3HighScore");

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

    public void Die()
    {
        player.transform.position = startPos;
        GameManager.timer = 0;
        for(int i = 0; i < bottles.Length; i++)
        {
            bottles[i].SetActive(true);
        }
        GameManager.isPaused = false;
        GameManager.hasStarted = false;
        GameManager.rumBottles = 0;
        Init();

        //grapple.SetActive(true);
    }

    public static void Win()
    {
        finalTime = GameManager.timer;
        finalRumBottles = GameManager.rumBottles;



        if (finalTime <= fastestTime)
        {
            fastestTime = finalTime;
            PlayerPrefs.SetFloat("level3HighScore", fastestTime);
            Debug.Log("updated score 2 " + PlayerPrefs.GetFloat("level3HighScore"));
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
