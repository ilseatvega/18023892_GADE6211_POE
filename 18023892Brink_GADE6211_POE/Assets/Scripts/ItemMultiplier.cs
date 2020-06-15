using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMultiplier : MonoBehaviour
{
    //sound
    private AudioSource multiplyAudio;
    //called bool that determines if the multiplier has been called
    private bool called = false;
    //environment manager
    private GameObject envMan;

    private void Start()
    {
        //get audio source component
        multiplyAudio = GetComponent<AudioSource>();
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }
    //coroutine for destroying object
    IEnumerator TimerCoroutine(GameObject envManager)
    {
        //wait 8 seconds
        yield return new WaitForSecondsRealtime(10);

        //destroy the collar
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision multiply)
    {
        //if collar collides w player
        if (multiply.gameObject.tag == "Player" && !called)
        {
            //sound
            multiplyAudio.Play();
            //the mutiply active coroutine from the game manager to activate/deactivate the visual indicator
            StartCoroutine(envMan.GetComponent<GameManager>().MultActive());
            //set called to true so that it doesnt keep calling and setting multiplier to 2
            called = true;
            //set multiplier to 2
            envMan.GetComponent<GameManager>().Multiplier = 2;
            //call resertcoin from game manager to multiply coins
            StartCoroutine(envMan.GetComponent<GameManager>().ResetCoin());
            //start the coroutine that destroys the object
            StartCoroutine(TimerCoroutine(multiply.transform.gameObject));
            //collider of the multiplier is disabled
            GetComponent<BoxCollider>().enabled = false;
            //using a foreach so that every child in the collar has their mesh turned off
            foreach (Transform child in transform)
            {
                try
                {
                    //turn off collar mesh renderer
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }
    }
}
