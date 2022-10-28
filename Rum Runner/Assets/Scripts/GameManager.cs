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
        PlayerPrefs.GetFloat("fastestTimeLv1", 100.0f);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.HasKey("fastestTimeLv1"));

    }

    // Update is called once per frame
    void Update()
    {
        fastestTime = PlayerPrefs.GetFloat("fastestTimeLv1");
        Debug.Log(fastestTime);


        if (!isPaused)
        {
            timer += Time.deltaTime;
            timeText.text = ("Time: " + timer.ToString("F2") + "s");
            scoreText.text = ("Bottles Collected: " + rumBottles.ToString());
            fastestTimeText.text = ("Fastest Time: " + fastestTime.ToString("F2") + "s");


            if (rumBottles >= 3)
            {
                exit.SetActive(true);
            }
        }
        pauseScreen.SetActive(isPaused);

    }


    public static void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

        if (finalTime <= fastestTime)
        {
            PlayerPrefs.SetFloat("fastestTimeLv1", finalTime);
            PlayerPrefs.Save();
            Debug.Log("new fastest: " + PlayerPrefs.GetFloat("fastestTimeLv1").ToString());

            fastestTime = PlayerPrefs.GetFloat("fastestTimeLv1");
        }

        SceneManager.LoadScene("WinScreen");


    }
}
