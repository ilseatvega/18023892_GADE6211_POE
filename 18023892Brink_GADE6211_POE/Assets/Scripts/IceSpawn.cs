using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpawn : MonoBehaviour
{
    //will be used to get status from bossstatus
    private IceBossStatus _status;
    //a transform type that holds the locations hail can spawn in (they are empty objs childed to the ground)
    Transform[] locs;
    //the prefab (hail)
    [SerializeField] GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        //
        _status = GameObject.FindGameObjectWithTag("Manager").GetComponent<IceBossStatus>();

        //getting the empty location children and = them to locs since they represent the locs
        locs = new Transform[3] { transform.GetChild(1).transform, transform.GetChild(2).transform, transform.GetChild(3).transform };
        //if the boss status is true (boss is active)
        if (_status.IceStatus == true)
        {
            //foreach to loop through the possible locations
            foreach (Transform loc in locs)
            {
                //randomise to determine what % chance it has of spawning
                if (Random.Range(0, 101) <= 25)
                {
                    //start the delay spawn coroutine
                    StartCoroutine(delaySpawn(loc.position));
                }
            }
        }
    }
    //method to spawn the hail in a specific (one of three lanes) randomised location
    private void SpawnIce(Vector3 loc)
    {
        //instatiate the prefab
        GameObject instance = Object.Instantiate(prefab, loc, prefab.transform.rotation);
    }
    //dealy spawn coroutine so that the hail doesnt spawn too slowly
    //now it spawns close to player
    IEnumerator delaySpawn(Vector3 loc)
    {
        //wait 8 seconds
        yield return new WaitForSeconds(8f);
        //spawn hail in a location
        SpawnIce(loc);
    }
}
