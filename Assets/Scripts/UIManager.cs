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
        highscoreText.text = "Highscore: " + GameStateManager.highscore.ToString();
        currentScoreText.text = "Current Score: " + GameStateManager.currentScore.ToString();
        currentDifficultyText.text = "Current Difficulty: " + GetDifficultyString();
        ballPointWorthText.text = "A Ball is worth " + GameStateManager.currentScoreIncrement.ToString() + " points!";
    }

    // Returns the difficulty depending on the int representation in GameStateManger. Easy, Medium, or Hard. 
    private string GetDifficultyString()
    {
        string difficulty = "";
        switch(GameStateManager.difficulty)
        {
            case 0:
                difficulty = "Easy";
                break;
            case 1:
                difficulty = "Medium";
                break;
            case 2:
                difficulty = "Hard";
                break;
            default:
                break;
        }
        return difficulty;
    }
}
