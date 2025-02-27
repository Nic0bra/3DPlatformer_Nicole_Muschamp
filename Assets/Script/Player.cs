using UnityEngine;

public class Player : MonoBehaviour
{
    //Initialize variables
    float speed;
    float jumpForce;
    float gravity;
    float health;
    Vector3 movement;
    CharacterController controller;
    bool grounded;
    [SerializeField] Animator bigVegasAnimator;
    [SerializeField] PlayerStats bigVegasStats;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        speed = bigVegasStats.speed;
        jumpForce = bigVegasStats.jumpForce;
        gravity = bigVegasStats.gravity;
        health = bigVegasStats.health;
    }


    // Update is called once per frame
    void Update()
    {
        //Input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        //Make jog animation
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


        //Hyde is cool


        //Check if grounded
        grounded = Physics.Raycast(transform.position + new Vector3( 0, -1, 0), Vector3.down, 1);


        //Make grounded animation
        bigVegasAnimator.SetBool("onGround", grounded);


        //Make that jawn jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            movement.y = jumpForce;
            bigVegasAnimator.SetTrigger("jump");
        }


        //Have controller move based on movement and delta time
        controller.Move(movement * Time.deltaTime);


        //Change the way the character faces
        if (xInput != 0 || zInput != 0)
            transform.forward = new Vector3(xInput, 0, zInput);
    }




    //Check if that jawn stepped on fire cube
    private void OnCollisionEnter(Collision collision)
    {
        //Get the game objects
        FireCube fireCube = collision.gameObject.GetComponent<FireCube>();
        Goal goal = collision.gameObject.GetComponent<Goal>();

        //Reduce health if player on fire cube
        if (fireCube != null)
        {
            health -= fireCube.damage;
                
            //check if player died
            if (health <= 0)
            {

            }
        }

        //Check if player reached goal
    }
}
// skibidi toilets are cool like brainrot :]