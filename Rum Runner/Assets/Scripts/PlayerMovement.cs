using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region  Player movement
    public Vector3 playerPosition = Vector3.zero;
    public Vector3 direction = Vector3.right;
    public Vector3 velocity = Vector3.zero;
    #endregion

    public float speed = 5f;
    public float maxSpeed = 5f;

    public float jumpForce= 5f;
    public Vector3 gravity = Vector3.down;

    public Vector2 playerHorizInput;
    public bool playerJumping;

    #region Camera vars
    private Camera cam;
    private float halfCamHeight;
    private float halfCamWidth;
    #endregion

    void Start()
    {
        //  Set the starting Spaceship position to the current position of the GameObject
        playerPosition = transform.position;

        gravity *= 3f;
        jumpForce = 5f;
        

        // Set camera variables
        cam = Camera.main;
        halfCamHeight = cam.orthographicSize;
        halfCamWidth = halfCamHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        playerJumping = false;

        //velocity += gravity * Time.deltaTime;
        if (playerHorizInput.x > 0)
        {
            // Move Right
            direction = Vector3.right;
            velocity += speed * direction * Time.deltaTime;
        }else if (playerHorizInput.x < 0){
            // Move Left
            direction = Vector3.left;
            velocity += speed * direction * Time.deltaTime;
        }
       // else if (playerJumping){
            // Move up
       //     direction = Vector3.up;
       //     velocity += jumpForce * direction * Time.deltaTime;
       // }
        else
        {
            velocity = Vector3.zero;
        }

         // Limit Velocity to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Calc new position
        playerPosition += velocity * Time.deltaTime;

        //  Check to make sure the Player is still on the screen
        BounceOffWalls();

        // Appy the movement to the GameObject
        transform.position = playerPosition;
    }

    // Check if the Player has left the screen
    // if so move it back same side
    void BounceOffWalls()
    {
        // Spaceship Position Wrapping
        // Goes off the Right
        if (playerPosition.x > halfCamWidth)
        {
            velocity.x *= -1f;
        }

        // Goes off the Left
        if (playerPosition.x < -halfCamWidth)
        {
            velocity.x *= -1f;
        }

        // Goes off the Top
        if (playerPosition.y > halfCamHeight)
        {
            playerPosition.y = halfCamHeight;
            transform.position = playerPosition;
            //velocity.y *= -1f;
        }

        // Goes off the Bottom
        if (playerPosition.y < -halfCamHeight)
        {
            playerPosition.y = -halfCamHeight;
            transform.position = playerPosition;
            //velocity.y *= -1f;
        }
    }

    public void OnMove(InputValue Value)
    {
        playerHorizInput = Value.Get<Vector2>();
        Debug.Log("move:" + playerHorizInput);
    }

    public void OnJump(InputValue Value)
    {
        playerJumping = Value.isPressed;
        Debug.Log("move:" + Value.isPressed);
    }
}