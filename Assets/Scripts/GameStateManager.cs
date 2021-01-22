using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static int currentScore;
    public static int currentScoreIncrement;
    public static bool isGameOver;
    public static float timer;
    public static int difficulty; // There are 3 difficulties of 0, 1, and 2. The difficulty increases with increasing int. 

    // These timer thresholds will determine when the difficulty of the game will increase.
    // For example, after the game timer reaches mediumTimerThreshold, the game will transition to a medium difficulty level. 
    public float mediumTimerThreshold;
    public float hardTimerThreshold;

    public int increasePointThreshold;
    private int thresholdCount = 0;

    // Set all fields to its original state for when the game starts or is restarted. 
    void Start()
    {
        currentScore = 0;
        currentScoreIncrement = 1;
        isGameOver = false;
        thresholdCount = 0;
        timer = 0f;
        difficulty = 0;
    }

    void Update()
    {
        SetCurrentScoreIncrement();
        ManageTimerAndDifficulty();
    }

    /*   
    *   Check and determine the point(s) that the player will gain when collecting a ball. 
    *   After every 5 points earned, the next point earned is increased by 1. 
    */
    private void SetCurrentScoreIncrement()
    {
        if (thresholdCount == increasePointThreshold)
        {
            thresholdCount = 0;
            currentScoreIncrement++;
        }
    }

    /*   
    *   Handles the timer and increases the difficulty of the game when the timer thresholds are met for 
    *   certain difficulties. 
    */
    private void ManageTimerAndDifficulty()
    {
        timer += Time.deltaTime;
        if (timer > mediumTimerThreshold && difficulty == 0)
        {
            difficulty++;
        } else if (timer > hardTimerThreshold && difficulty == 1)
        {
            difficulty++;
        }
    }
}
