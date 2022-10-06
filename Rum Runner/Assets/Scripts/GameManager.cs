using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private float timer;
    [SerializeField] GameObject exit;
    [SerializeField] Text time;
    [SerializeField] Text score;

    public int levelScore;
    public static int rumBottles = 0;
    public static bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        //isPaused = false;
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
            time.text = ("Time: " + timer.ToString("F2"));
            score.text = ("Bottles Collected: " + rumBottles.ToString());

            if(rumBottles >= 3)
            {
                exit.SetActive(true);
            }
        }
    }
}
