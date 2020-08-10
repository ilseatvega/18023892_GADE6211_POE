using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//so that i can use Text
using UnityEngine.UI;
//
using UnityEngine.Events;

using System.IO;
//added to control scene
using UnityEngine.SceneManagement;

public class IceTrigger : MonoBehaviour
{
    //scoretext gameobj - the text parented to the canvas that displays the score
    public GameObject LVLtext;
    //boss lvl score
    public int LVLscore;

    //unity event
    public UnityEvent onDisable;

    //bool to track the boss enabled event
    public bool isEnabled = false;

    //sound
    public AudioSource bgMusic;
    //sound
    private AudioSource ice;
    //light of the sky - will darken once boss is spawned
    public Light skyLight;
    //normal sky material when boss in inactive
    public Material normalSky;
    //overcast sky when boss activates
    public Material overcastSky;
    //environment manager
    private GameObject envMan;
    //bool to see if boss is triggered
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        //sound
        ice = GetComponent<AudioSource>();
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }

    private void FixedUpdate()
    {
        //if isenabled is true
        if (isEnabled)
        {
            //if not yet triggered
            if (!triggered)
            {
                //set triggered to true
                triggered = true;
                //play sound
                ice.Play();
                bgMusic.volume = 0.05f;
                //start the coroutine that will stop boss after certain amount of seconds
                StartCoroutine(stopBoss());
                //refer to the bossstatus script
                IceBossStatus reference = GameObject.FindGameObjectWithTag("Manager").GetComponent<IceBossStatus>();
                //set status to true
                reference.IceStatus = true;
                //set skybox to overcast sky
                RenderSettings.skybox = overcastSky;
                //set light intensity lower (darker)
                skyLight.intensity = 1.1f;
            }
        }
        //coroutine to stop boss after certain amount of secs
        IEnumerator stopBoss()
        {
            //wait
            yield return new WaitForSeconds(30f);
            LVLScoreText();
            onDisable.Invoke();
            //set triggered to false
            triggered = false;
            //set isenabled to false
            isEnabled = false;
            //stop sound
            ice.Stop();
            bgMusic.volume = 0.1f;
            //refer to the bossstatus script
            IceBossStatus reference = GameObject.FindGameObjectWithTag("Manager").GetComponent<IceBossStatus>();
            //set status to false
            reference.IceStatus = false;
            //set skybox back to normal
            RenderSettings.skybox = normalSky;
            //set light intensity bac to normal brightness
            skyLight.intensity = 1.3f;
            //add 50 to the score since boss is beaten
            envMan.GetComponent<GameManager>().score += 50;
            //load field level (so now it will loop)
            SceneManager.LoadScene(sceneName: "FieldLevel");
        }
    }
    //the method that will be added to the list of the fieldbossevent
    public void trigger(bool val)
    {
        isEnabled = val;
    }
    //the method that will be added to the list of the snowbossevent
    public void addScore()
    {
        PersistentServices.increaseBossScore();
    }

    public void LVLScoreText()
    {
        //having lvl score text reflect the lvl score
        LVLtext.GetComponent<Text>().text = PersistentServices.getScore();
    }
}
