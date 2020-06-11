using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroy : MonoBehaviour
{
    //creating a gameobject that holds the player
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player is equal to the player object (using tag to find it)
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if the position of this object is smaller than the position of the player (behind player) and 40 units away
        if (this.transform.position.z < player.transform.position.z - 500)
        {
            //destroy the game object this script is attached to (field prefab)
            Destroy(this.gameObject);
        }
    }
}
