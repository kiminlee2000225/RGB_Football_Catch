using System.Collections;
using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    public Transform shootPosition;
    public Transform shootBallParent;
    private BallLoader ballLoader;

    // Set these values in the inspector.
    public float easyInterval;
    public float mediumInterval;
    public float hardInterval;

    public float initialWaitTime; // Represents the initial wait time in seconds, allowing players to read the controls.
    private bool initialWaitCompleted; // Represents if the initial wait time has passed.

    private bool waitToShoot;

    // Set up the BallLoader component from the same GameObject and wait for the specified time to let players read the controls. 
    private void Start()
    {
        ballLoader = GetComponent<BallLoader>();
        initialWaitCompleted = false;
        StartCoroutine(WaitForPlayerToRead());
    }

    /*   
    *  Generate and shoot the ball when the machine is not waiting for a time interval to shoot a new ball.
    *   Do not generate and shoot balls if the game is over, or if the inital wait time has not passed (for the
    *   players to read the controls). 
    */
    void Update()
    {
        if (!waitToShoot && !GameStateManager.isGameOver && initialWaitCompleted)
        {
            SetWaitTimeAndShoot();
        }
    }

    // Set the time interval for the balls to be shot depending on the game difficulty, then generate and shoot the ball.
    private void SetWaitTimeAndShoot()
    {
        float secondsToWait = 0f;
        switch(GameStateManager.difficulty)
        {
            case 0:
                secondsToWait = easyInterval;
                break;
            case 1:
                secondsToWait = mediumInterval;
                break;
            case 2:
                secondsToWait = hardInterval;
                break;
            default:
                break;
        }
        StartCoroutine(WaitAndShoot(secondsToWait));
    }

    /*   
    *   <return>IEnumerator that is utilized to WaitForSeconds. This will not be utilized as a return variable. </return>
    *   
    *   Wait for the specified time (in seconds) for initialWaitTime. This will allow the players to get used to the UI and 
    *   to read and understand the controls. 
    */
    private IEnumerator WaitForPlayerToRead()
    {
        yield return new WaitForSeconds(initialWaitTime);
        initialWaitCompleted = true;
    }

    /*   
    *   <param name="seconds">A float that represents the amount of seconds the shooter should wait before shooting a ball</param>
    *   <return>IEnumerator that is utilized to WaitForSeconds. This will not be utilized as a return variable. </return>
    *   
    *   Wait for the specified number of seconds, then shoot a random ball projectile. Randomly generate a ball (which will vary in 
    *   their color and name), instantiate a ball prefab using the BallLoader Component, then shoot the ball by adding force to the 
    *   shooting position's forward vector. 
    */
    private IEnumerator WaitAndShoot(float seconds)
    {
        waitToShoot = true;
        yield return new WaitForSeconds(seconds);

        int id = Random.Range(0, 3); ;
        GameObject projectile = Instantiate(ballLoader.InstantiateBallWithId(id), shootPosition.position, shootPosition.rotation);
        projectile.transform.SetParent(shootBallParent);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(shootPosition.forward * -ballLoader.SetVelocityWithId(id));

        waitToShoot = false;
    }
}
