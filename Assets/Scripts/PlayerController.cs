using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    public float maxSpeed;
    public float jumpHeight = 100.0f;

    bool isOnGround = false;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    private float speed = 5.0f;

        // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        } else
        {
            maxSpeed = 5.0f;
        }
        //Create a 'float' that will be equal to the plays horizontal input
        float movementValueX = 1.0f;

        playerObject.velocity = new Vector2 (movementValueX * speed, playerObject.velocity.y);

        //Check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 2.0f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, jumpHeight));
        }
    }
    
}