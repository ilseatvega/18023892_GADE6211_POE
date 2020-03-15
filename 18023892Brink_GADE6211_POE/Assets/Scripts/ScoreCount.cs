using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    private GameObject player;

    private GameObject envMan;

    private bool scored;

    // Start is called before the first frame update
    void Start()
    {
        //player is equal to the player object (using tag to find it)
        player = GameObject.FindGameObjectWithTag("Player");

        envMan = GameObject.FindGameObjectWithTag("Manager");

        scored = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z <= player.transform.position.z && scored == false)
        {
            envMan.GetComponent<ScoreTrack>().AddScore();

            scored = true;
        }
    }
}
