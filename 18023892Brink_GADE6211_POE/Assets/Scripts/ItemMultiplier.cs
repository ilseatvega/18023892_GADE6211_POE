using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMultiplier : MonoBehaviour
{
    //coroutine for invincibility
    IEnumerator TimerCoroutine(GameObject Player)
    {
        //disable death script
        Player.GetComponent<PlayerDeath>().enabled = false;
        //change player layer to invincible - can collide with default objects without dying
        //ground has its own layer, tweaked the collisions in physics settings
        Player.layer = LayerMask.NameToLayer("Invincible");

        //wait 5 seconds
        yield return new WaitForSecondsRealtime(5);

        //change player layer back to default - can now collide with other default objects and die
        Player.layer = LayerMask.NameToLayer("Default");
        //enable death script
        Player.GetComponent<PlayerDeath>().enabled = true;
        //destroy the berry
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision multiply)
    {
        //if berry collides w player
        if (multiply.gameObject.tag == "Player")
        {
            //start the coroutine
            StartCoroutine(TimerCoroutine(multiply.transform.gameObject));
            //collider of the multiplier is disabled
            GetComponent<CapsuleCollider>().enabled = false;
            //turn mesh renderer off (object disappears but not destroyed)
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
