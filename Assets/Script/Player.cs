using UnityEngine;

public class Player : MonoBehaviour
{
    //Initialize variables
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 15;
    [SerializeField] float gravity = -30;
    Vector3 movement;
    CharacterController controller;
    bool grounded;
    [SerializeField] Animator bigVegasAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        if (xInput != 0 || zInput != 0)
        {
            bigVegasAnimator.SetBool("isJogging", true);
        }
        else
        {
            bigVegasAnimator.SetBool("isJogging", false);
        }


        movement.x = xInput * speed;
        movement.z = zInput * speed;

        //Set gravity
        movement.y += gravity * Time.deltaTime;

        //Set gravity right while grounded
        if (controller.isGrounded)
            movement.y = 0;

        //Check if grouned
        grounded = Physics.Raycast(transform.position + new Vector3( 0, -1, 0), Vector3.down, 1);

        bigVegasAnimator.SetBool("onGround", grounded);

        //Make that jawn jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            movement.y = jumpForce;
            bigVegasAnimator.SetTrigger("jump");
        }

        controller.Move(movement * Time.deltaTime);

        //Change the way they are facing
        if (xInput != 0 && zInput != 0)
            transform.forward = new Vector3(xInput, 0, zInput);
    }

    //Check for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
