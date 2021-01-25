using System.Collections;
using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    public Transform shootPosition;
    public Transform shootBallParent;
    private BallLoader ballLoader;

    // Set these values in the inspector
    public float easyInterval;
    public float mediumInterval;
    public float hardInterval;

    private bool waitToShoot;

    // Set up the BallLoader component from the same GameObject
    private void Start()
    {
        ballLoader = GetComponent<BallLoader>();
    }

    /*   
    *  Generate and shoot the ball when the machine is not waiting for a time interval to shoot a new ball.
    *   Do not generate and shoot balls if the game is over. 
    */
    void Update()
    {
        if (!waitToShoot && !GameStateManager.isGameOver)
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
    *   <param name="seconds">A float that represents the amount of seconds the shooter should wait before shooting a ball</param>
    *   <return>IEnumerator that is utilized to WaitForSeconds. This will not be utilized as a return variable. </return>
    *   
    *   Wait for the specified number of seconds, then shoot a random ball projectile. Randomly generate a ball (which will vary in 
    *   their color and name), instantiate a ball prefab using the BallLoader Component, then shoot the ball by adding force to the 
    *   shooting position's forward vector. 
    */
    private IEnumerator WaitAndShoot(float seconds){
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
