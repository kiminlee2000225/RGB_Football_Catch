using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    public Transform shootPosition;
    public GameObject ballPrefab;
    public Transform shootBallParent;

    // 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(ballPrefab, shootPosition.position, shootPosition.rotation);
            projectile.transform.SetParent(shootBallParent);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(shootPosition.forward * -2000f);
        }
    }
}
