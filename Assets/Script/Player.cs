using UnityEngine;

public class Player : MonoBehaviour
{
    //Initialize variables
    public Vector3 startPosition;
    float speed;
    float jumpForce;
    float gravity;
    float health;
    float maxHealth;
    Vector3 movement;
    CharacterController controller;
    bool grounded;
    [SerializeField] Animator bigVegasAnimator;
    [SerializeField] PlayerStats bigVegasStats;
    [SerializeField] GameLogic gameLogic;
    public AudioSource jumpSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Load start screen
        gameLogic.startCanvas.SetActive(true);

        //Start Music
        gameLogic.PlayMusic();

        //Access character controller component
        controller = GetComponent<CharacterController>();

        //Set start position
        startPosition = new Vector3(0f, 1f, 0f);

        //Put the player in the start position
        ResetPosition();

        //Set variables according to PlayerStats script
        speed = bigVegasStats.speed;
        jumpForce = bigVegasStats.jumpForce;
        gravity = bigVegasStats.gravity;
        health = bigVegasStats.health;
        maxHealth = bigVegasStats.maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        //Get user input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        //Make jog animation according to boolean value
        if (xInput != 0 || zInput != 0)
        {
            bigVegasAnimator.SetBool("isJogging", true);
        }
        else
        {
            bigVegasAnimator.SetBool("isJogging", false);
        }


        //Set the x and z input with speed
        movement.x = xInput * speed;
        movement.z = zInput * speed;


        //Set gravity
        movement.y += gravity * Time.deltaTime;


        //Set gravity right while grounded
        if (controller.isGrounded)
            movement.y = 0;


        //Check if grounded
        grounded = Physics.Raycast(transform.position + new Vector3(0, -1, 0), Vector3.down, 1);


        //Make grounded animation
        bigVegasAnimator.SetBool("onGround", grounded);


        //Make character jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //play jump sound apply force and animation
            jumpSound.Play();
            movement.y = jumpForce;
            bigVegasAnimator.SetTrigger("jump");
        }


        //Have controller move based on movement and delta time
        controller.Move(movement * Time.deltaTime);


        //Change the way the character faces
        if (xInput != 0 || zInput != 0)
            transform.forward = new Vector3(xInput, 0, zInput);
    }



    //Check if that jawn collided
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Check if it hit the fire cube
        if (hit.gameObject.CompareTag("FireCube"))
        {
            //Take away health
            bigVegasStats.health -= 1f;

            //Check if player has health left
            if (bigVegasStats.health <= 0)
            {
                //Call Game Over Canvas
                gameLogic.GameOver();
            }
        }
        //Check if it hit the goal
        else if (hit.gameObject.CompareTag("Goal"))
        {
            //Call Game Win Canvas
            gameLogic.WinGame();
        }
    }

    //Reset Player Position
    public void ResetPosition()
    {
        //Turn off Character Control to move positions
        controller.enabled = false;

        //Move characrter to start position
        transform.position = startPosition;

        //Give character control back
        controller.enabled = true;
    }
}