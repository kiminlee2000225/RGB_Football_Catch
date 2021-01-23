using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static int currentScore;
    public static int currentScoreIncrement;
    public static bool isGameOver;
    public static float timer;
    public static int difficulty; // There are 3 difficulties of 0, 1, and 2. 0 = easy, 1 = medium, 2 = hard difficulty.
    public static int highscore; // The highscore should be set to 0 if it is the player's first time playing.

    // These timer thresholds will determine when the difficulty of the game will increase.
    // For example, after the game timer reaches mediumTimerThreshold, the game will transition to a medium difficulty level. 
    // Set these values in the inspector
    public float mediumTimerThreshold;
    public float hardTimerThreshold;

    // Set this value in the inspector
    public int increasePointThreshold;
    public static int thresholdCount; // Determines when to increase the ball point worth.
    public static bool justIncremented; // Is true if the ball point worth has just increased. Is false if another ball is caught.

    // Set all fields to its original state for when the game starts or is restarted. 
    void Start()
    {
        currentScore = 0;
        currentScoreIncrement = 1;
        isGameOver = false;
        thresholdCount = 0;
        timer = 0f;
        difficulty = 0;
        SaveManager.LoadGame();
    }

    /*   
    *   If the game is not over, update the diffulcty and the ball point worth depending on
    *   how many balls have been collected. Otherwise, the game is over, so check if player
    *   achieved a highscore. If so, save the game to update the saved highscore. 
    */
    void Update()
    {
        if (!isGameOver)
        {
            SetCurrentScoreIncrement();
            ManageTimerAndDifficulty();
        } else
        {
            SetHighscore();
        }
    }

    /*   
    *   Check and determine the point(s) that the player will gain when collecting a ball. 
    *   After every 5 balls have been collected, the next point earned is increased by 1. 
    *   In other words, the ball point worth is increased by 1 after every 5 balls caught. 
    */
    private void SetCurrentScoreIncrement()
    {
        if(currentScore % increasePointThreshold == 0 && !justIncremented && currentScore != 0)
        {
            justIncremented = true;
            currentScoreIncrement++;
        }
    }

    /*   
    *   Checks if the current score is higher than the saved highscore. If so, update the saved
    *   highscore. This should be done after the highscore is displayed in the UI so that the 
    *   new highscore is not considered and compared as the saved highscore. 
    */
    private void SetHighscore()
    {
        if (currentScore > highscore && UIManager.highScoreDisplayed)
        {
            highscore = currentScore;
            SaveManager.SaveGame();
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

    /*   
    *   Restarts the game. This will be utilized for the "Play Again" button. 
    */
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
