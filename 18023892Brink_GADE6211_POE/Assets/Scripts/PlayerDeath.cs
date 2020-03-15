using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //once player collides w obstacles
    void OnCollisionEnter(Collision obs)
    {
        //objects w game tag obstacle
        if (obs.gameObject.tag == "Obstacle")
        {
            //Debug.Log("dead");
            //quit for now, but will replace this w load scene once i have it - just for the prototype
            Application.Quit();
            //stop playing in editor
            UnityEditor.EditorApplication.isPlaying = false;
            //Time.timeScale = 0;
        }
    }
}
