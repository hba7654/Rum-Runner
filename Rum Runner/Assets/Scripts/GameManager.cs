using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float timer;

    public int levelScore;
    public static int rumBottles = 0;
    public static bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        //isPaused = false;
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
            Debug.Log("time: " + timer.ToString("F2"));
            Debug.Log("score: " + rumBottles.ToString());
        }
    }
}
