using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
    {
    //environment manager
    private GameObject envMan;

    // Start is called before the first frame update
    void Start()
    {
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
    }

    private void OnCollisionEnter(Collision coin)
    {
        //if collides w player
        if (coin.gameObject.tag == "Player")
        {
            //calling on the addcoin method from the scoretrack script
            envMan.GetComponent<GameManager>().AddCoins();
            //destroy the coin
            Destroy(this.gameObject);
        }
    }
}
