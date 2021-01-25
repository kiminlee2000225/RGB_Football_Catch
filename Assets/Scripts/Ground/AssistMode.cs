using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AssistMode script to visually help the players by indicating where the balls will land
public class AssistMode : MonoBehaviour
{
    public GameObject assist;
    private bool assistOn;

    // Set helper off when game is started.
    void Start()
    {
        assistOn = false;
    }

    // Set helper on/off when the player presses the spacebar. 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            assistOn = !assistOn;
        }

        assist.SetActive(assistOn);
    }
}
