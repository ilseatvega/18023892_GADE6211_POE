using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added to control scene
using UnityEngine.SceneManagement;

public class RestartPlay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //if r key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            //timescale back to 1
            Time.timeScale = 1;
            //reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
