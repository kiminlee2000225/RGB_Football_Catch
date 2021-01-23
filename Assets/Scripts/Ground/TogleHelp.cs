using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleHelp : MonoBehaviour
{
    public GameObject helper;
    private bool helperOn;

    // Set helper off when game is started.
    void Start()
    {
        helperOn = false;
    }

    // Set helper on/off when the player presses the spacebar. 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            helperOn = !helperOn;
        }
        if (helperOn)
        {
            helper.SetActive(true);
        } else
        {
            helper.SetActive(false);
        }
    }
}
