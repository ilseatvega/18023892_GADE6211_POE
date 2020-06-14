using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHailSpawn : MonoBehaviour
{
    //will be used to get status from bossstatus
    private BossStatus _status;
    //a transform type that holds the locations hail can spawn in (they are empty objs childed to the ground)
    Transform[] locs;
    //the prefab (hail)
    [SerializeField] GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        //
        _status = GameObject.FindGameObjectWithTag("Manager").GetComponent<BossStatus>();

        //getting the empty location children and = them to locs since they represent the locs
        locs = new Transform[3] { transform.GetChild(7).transform, transform.GetChild(8).transform, transform.GetChild(9).transform };
        //if the boss status is true (boss is active)
        if (_status.Status == true)
        {
            //foreach to loop through the possible locations
            foreach (Transform loc in locs)
            {
                //randomise to determine what % chance it has of spawning
                if (Random.Range(0,101) <= 20)
                {
                    //start the delay spawn coroutine
                    StartCoroutine(delaySpawn(loc.position));
                }
            }
        }
    }
    //method to spawn the hail in a specific (one of three lanes) randomised location
    private void SpawnHail(Vector3 loc)
    {
        //instatiate the prefab
        GameObject instance = Object.Instantiate(prefab, loc, prefab.transform.rotation);
        //float that is used to scale the hail between 50 and 150 (normal scale is 100)
        float ran = Random.Range(instance.transform.localScale.x - 50, instance.transform.localScale.x + 50);
        //scale the object - vector is so that it can scale equally on x,y and z (doesnt stretch/squash)
        instance.transform.localScale = new Vector3(ran, ran, ran);
    }
    //dealy spawn coroutine so that the hail doesnt spawn too slowly
    //now it spawns close to player
    IEnumerator delaySpawn(Vector3 loc)
    {
        //wait 8 seconds
        yield return new WaitForSeconds(8f);
        //spawn hail in a location
        SpawnHail(loc);
    }

}
