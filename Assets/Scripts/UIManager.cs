using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text highscoreText;
    public TMP_Text currentScoreText;
    public TMP_Text currentDifficultyText;
    public TMP_Text ballPointWorthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = GetHighscoreString();
        currentScoreText.text = GetCurrentScoreString();
        currentDifficultyText.text = GetDifficultyString();
        ballPointWorthText.text = GetBallPointWorthString();
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
        switch(GameStateManager.difficulty)
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
}
