using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initialize variables
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float gravity = -1;
    Vector3 movement;
    CharacterController controller;

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

        movement.x = xInput * speed;
        movement.z = zInput * speed;

        //Set gravity
        movement.y += gravity * Time.deltaTime;

        //Set gravity right while grounded
        if (controller.isGrounded)
            movement.y = 0;

        //Make that jawn jump
        if (Input.GetButtonDown("Jump"))
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
