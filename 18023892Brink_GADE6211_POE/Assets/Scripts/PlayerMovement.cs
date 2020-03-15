using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //rip char controller, after finding out how difficult it is to use for jumping (and it was making my restart buggy??) :(
    //wont be missed tbh
    //private CharacterController catControl;

    //speed of the player
    public float speed = 0f;
    //tracks the lane the player is in
    private int laneTrack;
    
    public float jump = 0f;
    Rigidbody rb;

    bool isGrounded = true;

    Animator catAnim;

    // Start is called before the first frame update
    void Start()
    {
        //the catcontroller is = to the specific character controller that is attached to it
        //catControl = GetComponent<CharacterController>();
        //setting the lane track to 0 as the player spawns in the middle of the 3 lanes (0)
        laneTrack = 0;

        rb = GetComponent<Rigidbody>();

        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                catAnim.SetBool("Jump", true);
                rb.constraints = ~RigidbodyConstraints.FreezePositionY;
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                isGrounded = false;
            }

        if (Physics.Raycast(transform.position, Vector3.down, 0.3f))
        {
            catAnim.SetBool("Jump", false);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.3f);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("grounded");
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("not grounded");
            isGrounded = false;
        }
    }
}
