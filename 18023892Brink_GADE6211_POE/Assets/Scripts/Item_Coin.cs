using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coin)
    {
        if (coin.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
