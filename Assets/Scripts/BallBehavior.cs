using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    /* 
     * If the ball collides with the Player, grant the player point(s). 
     * If the ball collides with the Ground, it is game over.
     * Destroy the ball gameobject when collided with another gameobejct other than the BallShootMachine, 
     * since it will be shot out from it. 
    */    
    private void OnTriggerEnter(Collider other)
    {
        switch(other.name)
        {
            case "Player":
                GameStateManager.currentScore += GameStateManager.currentScoreIncrement;
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
