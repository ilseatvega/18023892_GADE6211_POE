using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
   //when colliding w the object
    private void OnTriggerEnter(Collider other)
    {
        //destroy objects
        Object.Destroy(other.gameObject);
    }
}
