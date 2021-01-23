using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraView : MonoBehaviour
{
    // Lock the cursor and make it invisible, since the player will not have to utilize the mouse during gameplay.
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
