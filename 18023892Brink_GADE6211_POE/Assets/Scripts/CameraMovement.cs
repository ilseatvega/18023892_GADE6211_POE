using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //transform that uses the transform of the player (parented an empty gameobj to the player)
    public Transform player;
    //the offset of the camera - so that the x and y dont move
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //changing this cameras pos to have the x and y match the offset numbers (manual) and have the z follow the player transform
        transform.position = new Vector3(offset.x, offset.y, player.position.z);
    }
}
