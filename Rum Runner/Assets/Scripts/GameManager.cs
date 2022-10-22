using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float finalTime;
    public static int finalRumBottles;
    public static float fastestTime;

    private static float timer;
    [SerializeField] GameObject exit;
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;
    [SerializeField] Text fastestTimeText;


    public int levelScore;
    public static int rumBottles = 0;
    public static bool isPaused;
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            timer += Time.deltaTime;
            timeText.text = ("Time: " + timer.ToString("F2") + "s");
            scoreText.text = ("Bottles Collected: " + rumBottles.ToString());

<<<<<<< HEAD
            if (rumBottles >= 3)
=======
            if(timer < fastestTime)
            {
                fastestTime = timer;
                Debug.Log(fastestTime);
            }

            if(rumBottles >= 3)
>>>>>>> 851fb780883bdf2af02769a763859dae4ef9f053
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

        if (finalTime <= fastestTime)
        {
            fastestTime = finalTime;
        }

        SceneManager.LoadScene("WinScreen");


    }
}
