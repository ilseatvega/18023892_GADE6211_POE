using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailDestroy : MonoBehaviour
{
    //when colliding w the haildestruction object
    private void OnTriggerEnter(Collider other)
    {
        //destroy objects (hail)
        Object.Destroy(other.gameObject);
    }
}
