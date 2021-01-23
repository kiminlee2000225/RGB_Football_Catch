using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a Save object
[System.Serializable]
public class Save
{
    public int highscore;

    public Save()
    {
        highscore = GameStateManager.highscore;
    }

}
