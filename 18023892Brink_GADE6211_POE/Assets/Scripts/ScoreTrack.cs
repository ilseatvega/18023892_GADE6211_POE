﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//so that i can use Text
using UnityEngine.UI;
//for events
using UnityEngine.Events;

public class ScoreTrack : MonoBehaviour
{
    
    //player
    private GameObject player;
    //environment manager
    private GameObject envMan;
    //bool to determine whether or not the object has been scored
    private bool scored;

    // Start is called before the first frame update
    void Start()
    {
        //player is equal to the player object(using tag to find it)
        player = GameObject.FindGameObjectWithTag("Player");
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
        //setting scored to false - player has not scored
        scored = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if this obstacle's z pos is smaller than or = to than the player's z pos ( behind or next to them) and they havent scored yet
        if (this.transform.position.z <= player.transform.position.z && scored == false)
        {
                //call addscore method and track score
                envMan.GetComponent<GameManager>().AddScore();
                //they have now scored so set this to true
                //otherwise it will keep adding a score for the same obstacle until it is destroyed
                scored = true;
        }
        //if player is dead
        if (player.GetComponent<PlayerDeath>().isAlive == false)
        {
            //get final score
            envMan.GetComponent<GameManager>().FinalScore();
        }
    }
}
