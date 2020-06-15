using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //sound
    private AudioSource death;
    //environment manager
    private GameObject envMan;
    //bool to determine if player is alive
    public bool isAlive;

    
        
    void Start()
    {
        //get audio source component
        death = GetComponent<AudioSource>();
        //player isalive
        isAlive = true;
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }
    
    //once player collides w obstacles
    void OnCollisionEnter(Collision obs)
    {
        //objects w game tag obstacle
        if (obs.gameObject.tag == "Obstacle" || obs.gameObject.tag == "BossHail")
        {
            //player is dead
            isAlive = false;
            //play death sound
            death.Play();
            //calling the death method in scoretrack (script on envman gameobject)
            envMan.GetComponent<GameManager>().Death();
        }
    }
}
