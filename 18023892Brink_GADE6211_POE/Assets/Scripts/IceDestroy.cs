using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDestroy : MonoBehaviour
{
    //when colliding w the object
    private void OnTriggerEnter(Collider other)
    {
        //destroy objects (icile)
        Object.Destroy(other.gameObject);
    }
}
