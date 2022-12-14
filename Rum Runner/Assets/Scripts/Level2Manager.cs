using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    public Vector2 startPos;
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
    [SerializeField] private GameObject[] targets;
    [SerializeField] GameObject pistol;

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
        GameManager.level = 2;

        if (!PlayerPrefs.HasKey("level2HighScore"))
        {
            PlayerPrefs.SetFloat("level2HighScore", 1000);
        }

        Debug.Log("stored score 2 " + PlayerPrefs.GetFloat("level2HighScore"));
        fastestTime = PlayerPrefs.GetFloat("level2HighScore");

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
        for (int i = 0; i < bottles.Length; i++)
        {
            bottles[i].SetActive(true);
        }
        GameManager.isPaused = false;
        GameManager.hasStarted = false;
        GameManager.rumBottles = 0;
        Init();

        player.hasPistol = false;
        pistol.SetActive(true);

        for(int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].activeInHierarchy)
            {
                targets[i].SetActive(true);
                targets[i].GetComponent<Target>().ResetTarget();
            }
        }
    }

    public static void Win()
    {
        var L2 = new Level2Manager();

        finalTime = GameManager.timer;
        finalRumBottles = GameManager.rumBottles;

        if (finalRumBottles > L2.requiredScore)
        {
            finalTime += (float).5 * (L2.requiredScore - finalRumBottles);
        }


        if (finalTime <= fastestTime)
        {
            fastestTime = finalTime;
            PlayerPrefs.SetFloat("level2HighScore", fastestTime);
            Debug.Log("updated score 2 " + PlayerPrefs.GetFloat("level2HighScore"));
        }

        SceneManager.LoadScene("WinScreen");


    }
    public static void Nextlevel()
    {

        GameManager.totalTime += finalTime;
        GameManager.totalFastestTime += fastestTime;
        GameManager.totalRumBottles += finalRumBottles;

        SceneManager.LoadScene("Level 3");
    }
}
