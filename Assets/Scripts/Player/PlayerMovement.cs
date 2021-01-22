using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Set these values in the inspector
    public float moveSpeed;
    public float runSpeed;

    private bool isRunning;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Rigidbody rb;

    // Find the Character Controller and the Rigidbody of the player.
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();    
    }

    /*
    *  Move the player vertically one axis depending on the player inputs. 
    *  The player may use the arrow keys or WS to move. 
    *  If the player is holding the left shift key, increase the movement speed as the player should be running.
    */
    void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);

        float moveVertical = Input.GetAxis("Vertical");
        var input = transform.forward * moveVertical;
        input *= isRunning ? runSpeed : moveSpeed;
        moveDirection = input;

        controller.Move(moveDirection * Time.deltaTime);
    }

    /*   
     *   When this method is called, it indicates that the game is over, so the player controller and
     *   rigidbody collisions are disabled.
     */
    public void GameOver()
    {
        controller.enabled = false;
        rb.detectCollisions = false;
    }

}
