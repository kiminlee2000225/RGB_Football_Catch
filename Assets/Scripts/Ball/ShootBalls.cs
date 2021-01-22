using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    public Transform shootPosition;
    public Transform shootBallParent;
    private BallLoader ballLoader;

    // Set up the BallLoader component from the same GameObject
    private void Start()
    {
        ballLoader = GetComponent<BallLoader>();
    }

    // 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int id = Random.Range(0, 3);;
            GameObject projectile = Instantiate(ballLoader.InstantiateBallWithId(id), shootPosition.position, shootPosition.rotation);
            projectile.transform.SetParent(shootBallParent);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(shootPosition.forward * -ballLoader.SetVelocityWithId(id));
        }
    }
}
