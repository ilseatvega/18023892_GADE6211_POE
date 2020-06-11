using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //environment manager
    private GameObject envMan;
    //bool to determine if player is alive
    public bool isAlive;

    void Start()
    {
        //player isalive
        isAlive = true;
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }
    
    //once player collides w obstacles
    void OnCollisionEnter(Collision obs)
    {
        //objects w game tag obstacle
        if (obs.gameObject.tag == "Obstacle")
        {
            //Debug.Log("dead");

            //player is dead
            isAlive = false;
            //calling the death method in scoretrack (script on envman gameobject)
            envMan.GetComponent<ScoreTrack>().Death();
        }
    }
}
