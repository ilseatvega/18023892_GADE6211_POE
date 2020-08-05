using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HailBoss : MonoBehaviour
{
    //sound
    public AudioSource bgMusic;
    //sound
    private AudioSource ominous;
    //light of the sky - will darken once boss is spawned
    public Light skyLight;
    //normal sky material when boss in inactive
    public Material normalSky;
    //overcast sky when boss activates
    public Material overcastSky;
    //environment manager
    private GameObject envMan;
    //
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        //sound
        ominous = GetComponent<AudioSource>();
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }

    private void FixedUpdate()
    {
        //if score is 50,51 or 52 (player can pass up to 3 objects at a time which can make score skip 10 and jump to 12)
        if (envMan.GetComponent<GameManager>().score == 50 || envMan.GetComponent<GameManager>().score == 51 || envMan.GetComponent<GameManager>().score == 52)
        {
            //if not yet triggered
            if (!triggered)
            {
                //set triggered to true
                triggered = true;
                //play sound
                ominous.Play();
                bgMusic.volume = 0.05f;
                //start the coroutine that will stop boss after certain amount of seconds
                StartCoroutine(stopBoss());
                //refer to the bossstatus script
                BossStatus reference = GameObject.FindGameObjectWithTag("Manager").GetComponent<BossStatus>();
                //set status to true
                reference.Status = true;
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
            //set triggered to false
            triggered = false;
            //stop sound
            ominous.Stop();
            bgMusic.volume = 0.1f;
            //refer to the bossstatus script
            BossStatus reference = GameObject.FindGameObjectWithTag("Manager").GetComponent<BossStatus>();
            //set status to false
            reference.Status = false;
            //set skybox back to normal
            RenderSettings.skybox = normalSky;
            //set light intensity bac to normal brightness
            skyLight.intensity = 1.3f;
            //add 50 to the score since boss is beaten
            envMan.GetComponent<GameManager>().score += 50;
        }
    }
}
