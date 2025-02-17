using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initialize variables
    [SerializeField] float speed;
    Rigidbody rb;
    Vector3 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the player via its rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //Set movement variable
        movement = new Vector3(xInput, 0, zInput) * speed * Time.deltaTime;
        movement.y = rb.linearVelocity.y;
    }

    //Update for physics
    private void FixedUpdate()
    {
        //Apply movement
        rb.linearVelocity = movement;
    }
}
