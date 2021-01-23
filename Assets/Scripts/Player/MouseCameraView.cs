using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraView : MonoBehaviour
{
    //public float mouseSensitivity;
    private float rotation;

    // Lock the cursor and make it invisible, since the player will not have to utilize the mouse during gameplay.
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Allow player to rotate the camera on the X axis (vertically) with a 180 degrees span.
    void Update()
    {
/*        if (!GameStateManager.isGameOver)
        {
            float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            rotation -= moveY;
            rotation = Mathf.Clamp(rotation, -90.0f, 90.0f);
            transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        }*/
    }
}
