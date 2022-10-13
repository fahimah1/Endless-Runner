using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    public float jumpHeight = 100.0f;
    public Animator anim;

    private  bool doubleJump = true;

    bool isOnGround = false;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    public float speed = 10.0f;

        // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private bool isGrounded()
    {
        return isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.01f, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }


        //Create a 'float' that will be equal to the plays horizontal input
        float movementValueX = 1.0f;

        playerObject.velocity = new Vector2 (movementValueX * speed, playerObject.velocity.y);

        //Check to see if the ground check object is touching the ground
        

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isOnGround)
            {
                playerObject.AddForce(new Vector2(0.0f, jumpHeight));
            } 
            else {
                if (doubleJump) {
                    playerObject.AddForce(new Vector2(0.0f, jumpHeight));
                    doubleJump = false;
                }
            }
        }

        if (isOnGround) {
            doubleJump = true;
        }

        anim.SetBool("OnGround", isOnGround);
    
    }
    
}