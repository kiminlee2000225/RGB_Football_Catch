using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private bool triggered; // true if OnTriggerEnter is called. false otherwise.

    // Set the trigger bool to false since the ball shouldn't be triggered when instantiated.
    private void Start()
    {
        triggered = false;
    }

    /* 
     * If the ball collides with the Player, grant the player point(s). 
     * If the ball collides with the Ground, it is game over.
     * Destroy the ball gameobject when collided with another gameobejct other than the BallShootMachine, 
     * since it will be shot out from it. 
    */
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
            switch (other.name)
            {
                case "Player":
                    BallHitPlayer();
                    break;
                case "Ground":
                    GameStateManager.isGameOver = true;
                    break;
                default:
                    break;
            }

            if (!string.Equals(other.name, "BallShootMachine"))
            {
                Destroy(gameObject);
            }
        }
    }

    /* 
     * Called when the ball collides and triggers with the player. In other words, when the player 
     * collects the ball. Increases currentScore by the currentScoreIncrement, increases the
     * thresholdCount by 1, and sets justIncremented to false.
    */
    private void BallHitPlayer()
    {
        GameStateManager.currentScore += GameStateManager.currentScoreIncrement;
        GameStateManager.thresholdCount++;
        GameStateManager.justIncremented = false;
    }
}
