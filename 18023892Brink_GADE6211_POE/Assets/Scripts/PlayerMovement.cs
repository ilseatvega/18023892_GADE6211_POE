﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //rip char controller, after finding out how difficult it is to use for jumping (and it was making my restart buggy??) :(
    //wont be missed tbh
    //private CharacterController catControl;
    
    //speed of the player
    public float speed = 0f;
    //tracks the lane the player is in
    private int laneTrack;
    //flaot for the jump (how high player jumps)
    public float jump = 0f;
    //rigidbody of player
    Rigidbody rb;
    //to test if player is grounded
    bool isGrounded = true;
    //animator to switch between animation states when jumping - running
    Animator catAnim;

    // Start is called before the first frame update
    void Start()
    {
        //setting the lane track to 0 as the player spawns in the middle of the 3 lanes (0)
        laneTrack = 0;
        //setting rb = to the rigidbody attached to this object (player)
        rb = GetComponent<Rigidbody>();
        //setting catAnim = to the animator attached to this object (player)
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if player presses escape, app quits
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //if player is alive, move
        if (this.GetComponent<PlayerDeath>().isAlive == true)
        {
            //player moves forward automatically
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //if the player presses the left arrow key
            if (Input.GetKeyDown("left"))
            {
                //if the lane the player is in is NOT = to the -1 boundary set by the clamp
                if (laneTrack != Mathf.Clamp(laneTrack - 1, -1, 1))
                {
                    //-1 to the lanetrack and make sure they are still within bounds
                    laneTrack = Mathf.Clamp(laneTrack - 1, -1, 1);
                    //move the player 10 units to the left
                    this.transform.position += new Vector3(-10, 0, 0);
                }
            }

            //if the player presses the right arrow key
            if (Input.GetKeyDown("right"))
            {
                //if the lane the player is in is NOT = to the +1 boundary set by the clamp
                if (laneTrack != Mathf.Clamp(laneTrack + 1, -1, 1))
                {
                    //+1 to the lanetrack and make sure they are still within bounds
                    laneTrack = Mathf.Clamp(laneTrack + 1, -1, 1);
                    //move the player 10 units to the right
                    this.transform.position += new Vector3(10, 0, 0);
                }
            }
            //if player is on the ground and they press up arrow key to jump
            if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                //switch to jump animation
                catAnim.SetBool("Jump", true);
                //unfreeze the ypos so that the player can jump
                rb.constraints = ~RigidbodyConstraints.FreezePositionY;
                //using the rigidbody have them jump up and according to the jump variable
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                //set isgrounded to false as they are not grounded
                isGrounded = false;
            }
            //when the player is close enough to the ground it sets the jump animation to false
            if (isGrounded)
            {
                catAnim.SetBool("Jump", false);
            }
        }
    }
    //for the raycast, to visualise the raycast using a line
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        //drawing the line
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.3f);
    }

    void OnCollisionStay(Collision other)
    {
        //if player collides w ground
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("grounded");

            //they are grounded
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        //if player stops colliding w ground
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("not grounded");

            //they are not grounded
            isGrounded = false;
        }
    }
}
