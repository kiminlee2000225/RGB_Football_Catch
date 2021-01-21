using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static int currentScore;
    public static int currentScoreIncrement;
    public static bool isGameOver;

    public int increasePointThreshold = 5;
    private int thresholdCount = 0;

    // Set all fields to its original state for when the game starts or is restarted. 
    void Start()
    {
        currentScore = 0;
        currentScoreIncrement = 1;
        isGameOver = false;
        thresholdCount = 0;
    }

    void Update()
    {
        SetCurrentScoreIncrement();
    }

    /*   
    *   Check and determine the point(s) that the player will gain when collecting a ball. 
    *    After every 5 points earned, the next point earned is increased by 1. 
    */
    private void SetCurrentScoreIncrement()
    {
        if (thresholdCount == increasePointThreshold)
        {
            thresholdCount = 0;
            currentScoreIncrement++;
        }
    }
}
