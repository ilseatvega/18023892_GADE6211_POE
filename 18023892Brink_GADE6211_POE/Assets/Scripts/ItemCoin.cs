using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    //sound
    private AudioSource coinAudio;
    //environment manager
    private GameObject envMan;

    // Start is called before the first frame update
    void Start()
    {
        //get audio source component
         coinAudio = GetComponent<AudioSource>();
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }

    private void OnCollisionEnter(Collision coin)
    {
        //if collides w player
        if (coin.gameObject.tag == "Player")
        {
            //sound
            coinAudio.Play();
            //calling on the addcoin method from the scoretrack script
            envMan.GetComponent<GameManager>().AddCoins();
            //destroy the coin
            Destroy(this.gameObject);
        }
    }
}
