using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text highscoreText;
    public TMP_Text currentScoreText;
    public TMP_Text currentDifficultyText;
    public TMP_Text ballPointWorthText;
    public TMP_Text controlsText;

    public GameObject inGameUIPanel;
    public GameObject gameOverUIPanel;

    public TMP_Text isHighscoreUpdatedText;
    public TMP_Text gameOverHighscoreText;

    public static bool highScoreDisplayed; // Determines if the highscore UI for the GameOverPanel is shown or not

    // Set highScoreDisplayed to false and deactivate the gameOverUIPanel. Activate the inGameUIPanel when game starts. 
    private void Start()
    {
        highScoreDisplayed = false;
        inGameUIPanel.SetActive(true);
        gameOverUIPanel.SetActive(false);
    }

    /* 
     * Update the UI so that the InGameUI and the GameOverUI are displaye correctly. 
    */
    void Update()
    {
        SetInGameUIText();
        SetGameOverUIText();
    }

    /* 
     * Set the text values for the TMP components to be shown on the UI. 
     * The UI should represent the player's highscore, current score, the game's 
     * current difficulty, how many points a ball is currently worth, and controls. 
    */
    private void SetInGameUIText()
    {
        highscoreText.text = GetHighscoreString();
        currentScoreText.text = GetCurrentScoreString();
        currentDifficultyText.text = GetDifficultyString();
        ballPointWorthText.text = GetBallPointWorthString();
        controlsText.text = GetControlsStrings();
    }

    /* 
     * Sets the GameOverUI. If the player is unable to catch any ball, it is game over.
     * Display the GameOverUI and unlock the cursor for free movement. Show if the player
     * received a highscore or not. Either way, display the highscore and the score
     * the player got during the playthrough.
    */
    private void SetGameOverUIText()
    {
        if (GameStateManager.isGameOver && !highScoreDisplayed)
        {
            gameOverUIPanel.SetActive(true);
            inGameUIPanel.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            isHighscoreUpdatedText.text = GetIsHighscoreUpdatedString();
            gameOverHighscoreText.text = GetUpdatedHighscoreString();
            highScoreDisplayed = true;
            SaveManager.SaveGame();
        }
    }

    /* 
     * <returns>A string that represents the highscore.</returns>
     * 
     * The highscore represents the highest score that the player has been able to achieve
     * in the past. The highscore should be 0 if it is the player's first time playing. 
     * The format is "Highscore: [INTEGER]".
    */
    private string GetHighscoreString()
    {
        return "Highscore: " + GameStateManager.highscore.ToString();
    }

    /* 
     * <returns>A string that represents the current score.</returns>
     * 
     * The current score represents how many balls the player has caught. 
     * The format is "Current Score: [INTEGER]".
    */
    private string GetCurrentScoreString()
    {
        return "Current Score: " + GameStateManager.currentScore.ToString();
    }

    /* 
     * <returns>A string that represents the difficulty of the game.</returns>
     * 
     * Returns the difficulty depending on the int representation in GameStateManger. Easy, Medium, or Hard. 
     * The format is "Current Difficulty: [STRING]". 
    */
    private string GetDifficultyString()
    {
        string difficulty = "Current Difficulty: ";
        switch (GameStateManager.difficulty)
        {
            case 0:
                difficulty += "Easy";
                break;
            case 1:
                difficulty += "Medium";
                break;
            case 2:
                difficulty += "Hard";
                break;
            default:
                break;
        }
        return difficulty;
    }

    /* 
     * <returns>A string that represents the number of points a ball is worth.</returns>
     * 
     * Returns the point worth of the ball in the format of "[INTEGER] point!" or "[INTEGER] points!". 
     * A "s" is added at the end before the "!" if the point worth is more than 1 to make it plural. 
    */
    private string GetBallPointWorthString()
    {
        string worthString = "A Ball is worth " + GameStateManager.currentScoreIncrement.ToString() + " point";
        if (GameStateManager.currentScoreIncrement > 1)
        {
            worthString += "s";
        }
        return worthString + "!";

    }

    /* 
     * <returns>A string that represents the controls.</returns>
     * 
     * Returns the controls available to the player as a string. 
     * Include info about movement, running, and helper. 
    */
    private string GetControlsStrings()
    {
        string controls = "Controls: ";
        controls += "\nW S or Up Down arrow to move";
        controls += "\nHold Left Shift to run";
        controls += "\nPress Spacebar to toggle help";
        return controls;
    }

    /* 
     * <returns>A string that represents the score and if the player earned is a highscore or not.</returns>
     * 
     * Returns the point worth of the ball in the format of "Score: [INTEGER]" or 
     * "Score: [INTEGER] - New Highscore!". 
    */
    private string GetIsHighscoreUpdatedString()
    {
        string text = "Score: " + GameStateManager.currentScore;
        if (GameStateManager.currentScore > GameStateManager.highscore)
        {
            text += " - New Highscore!";
        }
        return text;
    }

    /* 
     * <returns>A string that represents the highscore when the game is over.</returns>
     * 
     * Returns the point worth of the ball in the format of "Highscore: [INTEGER]".
     * The text shows the player's score if the player was able to achieve a highscore.
     * Otherwise, it shows the saved highscore. 
     */
    private string GetUpdatedHighscoreString()
    {
        string text = "Highscore: ";
        if (GameStateManager.currentScore > GameStateManager.highscore)
        {
            text += GameStateManager.currentScore;
        } else
        {
            text += GameStateManager.highscore;
        }
        return text;
    }
}
