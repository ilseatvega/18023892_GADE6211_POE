using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //charactercontroller
    private CharacterController catControl;
    //speed of the player
    public float speed = 5f;
    //tracks the lane the player is in
    private int laneTrack;

    // Start is called before the first frame update
    void Start()
    {
        //the catcontroller is = to the specific character controller that is attached to it
        catControl = GetComponent<CharacterController>();
        //setting the lane track to 0 as the player spaws in the middle of the 3 lanes (0)
        laneTrack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //player moves forward automatically
        catControl.Move((Vector3.forward * speed) * Time.deltaTime);

        //if the player presses the left arrow key
        if (Input.GetKeyDown("left"))
        {
            //if the lane the player is in is NOT = to the -1 boundary set by the clamp
            if (laneTrack != Mathf.Clamp(laneTrack - 1, -1, 1))
            {
                //-1 to the lanetrack and make sure they are still within bounds
                laneTrack = Mathf.Clamp(laneTrack - 1, -1, 1);
                //move the player 10 units to the left using the char controller
                catControl.Move(Vector3.left * 10);
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
                //move the player 10 units to the right using the char controller
                catControl.Move(Vector3.right * 10);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
    }
}
