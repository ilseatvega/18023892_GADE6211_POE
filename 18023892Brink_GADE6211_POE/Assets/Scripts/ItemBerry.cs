using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBerry : MonoBehaviour
{
    //sound
    private AudioSource berryAudio;
    //environment manager
    private GameObject envMan;

    private void Start()
    {
        //get audio source component
        berryAudio = GetComponent<AudioSource>();
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }

    //coroutine for invincibility
    IEnumerator TimerCoroutine(GameObject Player)
    {
        //disable death script
        Player.GetComponent<PlayerDeath>().enabled = false;
        //change player layer to invincible - can collide with default objects without dying
        //ground has its own layer, tweaked the collisions in physics settings
        Player.layer = LayerMask.NameToLayer("Invincible");

        //wait 10 seconds
        yield return new WaitForSecondsRealtime(10);
        
        //change player layer back to default - can now collide with other default objects and die
        Player.layer = LayerMask.NameToLayer("Default");
        //enable death script
        Player.GetComponent<PlayerDeath>().enabled = true;
        //destroy the berry
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision berry)
    {
        //if berry collides w player
        if (berry.gameObject.tag == "Player")
        {
            //sound
            berryAudio.Play();
            //the mutiply active coroutine from the game manager to activate/deactivate the visual indicator
            StartCoroutine(envMan.GetComponent<GameManager>().BerryActive());
            //start the coroutine
            StartCoroutine(TimerCoroutine(berry.transform.gameObject));
            //collider of the berry is disabled
            GetComponent<CapsuleCollider>().enabled = false;
            //turn mesh renderer off (object disappears but not destroyed)
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
