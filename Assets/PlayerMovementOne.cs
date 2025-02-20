using UnityEngine;

public class PlayerMovementOne : MonoBehaviour
{
    //Initialize variables
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float gravity = -1;
    [SerializeField] Transform playerCam;
    Vector3 movement;
    CharacterController controller;
    bool grounded;
    

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

        Vector3 camForward = playerCam.forward;
        Vector3 camRight = playerCam.forward;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelMovement = zInput * camForward;
        Vector3 rightRelMovement = xInput * camRight;
        
        Vector3 relativeMovement = (forwardRelMovement + rightRelMovement) * speed;

        //Change the way they are facing
        if (xInput != 0 && zInput != 0)
            transform.forward = relativeMovement;

        relativeMovement.y = movement.y;
        movement = relativeMovement;

        //Set gravity
        movement.y += gravity * Time.deltaTime;

        //Set gravity right while grounded
        if (controller.isGrounded)
            movement.y = 0;

        //Check if grouned
        grounded = Physics.Raycast(transform.position + Vector3.down, Vector3.down, 1);

        //Make that jawn jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            movement.y = jumpForce;
        }

        controller.Move(movement * Time.deltaTime);
    }

//Check for collision
private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
