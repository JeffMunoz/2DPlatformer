// Author: Jeffry Munoz


using Scenes;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animations;
    public Joystick joystick;

    public Rigidbody2D playerRb;
    
    private float horizontalMovement = 0f;
    public float moveSpeed = 40f;
    private bool jump = false;
    private bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
         // horizontalMovement = Input.GetAxisRaw("Horizontal")* moveSpeed; //for keyboard control
         // animations.SetFloat("Speed", Mathf.Abs(horizontalMovement));
         
         // if (Input.GetButtonDown("Jump"))
         // {
         //     jump = true;
         //     animations.SetBool("IsJumping", true);
         // }
         // else if (Input.GetButtonDown("Crouch"))
         // {
         //     crouch = true;
         // }
         // else if(Input.GetButtonUp("Crouch"))
         // {
         //     crouch = false;
         // }
         
         
         // Touch Controls
         if (joystick.Horizontal >= .2f)
         {
             horizontalMovement = moveSpeed;
         }
         else if (joystick.Horizontal <= -.2f)
         {
             horizontalMovement = -moveSpeed;
         }
         else
         {
             horizontalMovement = 0;
         }
         animations.SetFloat("Speed", Mathf.Abs(horizontalMovement));
         
         float verticalMove = joystick.Vertical;
         
         if (verticalMove >= .5f)
         {
             jump = true;
             animations.SetBool("IsJumping", true);
         }
         else if (verticalMove <= -.5f)
         {
             crouch = true;
         }
         else
         {
             crouch = false;
         }

         

    }

    public void onLanding()
    {
        animations.SetBool("IsJumping", false);
    }

    public void onCrouch(bool IsCrouching)
    {
        animations.SetBool("IsCrouching", IsCrouching);
    }

    private void FixedUpdate() //this is not dependent on the refresh rate of the screen
    {
        // Time.fixedDelataTime Ensures that the player moved the same amount
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    
        if (playerRb.position.y < -5.5f)
        {
            FindObjectOfType<GameManager>().endGame();
        }else if (playerRb.position.x > 23.3f && playerRb.position.y >= 2.8f)
        {
            FindObjectOfType<GameManager>().winGame();
        }
        
    }
    

    

}