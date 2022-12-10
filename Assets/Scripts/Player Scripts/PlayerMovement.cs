using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;

    float direction = 0;

    public float speed = 100;

    public Rigidbody2D playerRB;

    // ref to jump level
    public float jumpLevel = 0.1f;


    // ref double jump
    int numJumps = 0;
    // jump check variable
    bool isGrounded;

    // ref to jump check object
    public Transform jumpCheck;


    public LayerMask groundLayer;
    
    //ref to animator 
    public Animator animator;

    // variable to check direction player is facing
    bool faceDirection = true;

    private void Awake()
    {

        controls = new PlayerControls();
        controls.Enable();

        controls.Ground.Move.performed += contxt =>
        {

            direction = contxt.ReadValue<float>();

        };


        controls.Ground.Jump.performed += contxt => Jump();
    }

 

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // checking if player is on ground using overlapCircle func w/ 0.1 radius
        isGrounded = Physics2D.OverlapCircle(jumpCheck.position, 0.1f, groundLayer);

        // changes animations depending on state of idle / run
        animator.SetBool("isGrounded", isGrounded);
        
        
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(direction));
        
        // checking both directions and flipping 
        if(faceDirection && direction < 0  || !faceDirection && direction >0)
        {
            Flip();
        }


    }

    void Flip()
    {
        // checking direction + changing player models 'x'
        
        faceDirection = !faceDirection;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);


    }

    // setting numJumps to 0 every time it jump() is called 
    // adds to numJumps every time the player jumps
    void Jump()
    {
        
        if (isGrounded && playerRB != null)
        {
            numJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpLevel);
            numJumps++;

            AudioManager.instance.Play("JUMP");
        }
        else
        {
            if(numJumps == 1 && playerRB != null)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpLevel);
                numJumps++;

                AudioManager.instance.Play("JUMP");
            }
        }
        
    }
}
