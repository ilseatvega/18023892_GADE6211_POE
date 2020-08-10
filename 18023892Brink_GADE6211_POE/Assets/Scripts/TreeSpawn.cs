using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    //will be used to get status from bossstatus
    private TreeBossStatus _status;
    //a transform type that holds the locations hail can spawn in (they are empty objs childed to the ground)
    Transform[] locs;
    //the prefab (hail)
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;

    // Start is called before the first frame update
    void Start()
    {
        //
        _status = GameObject.FindGameObjectWithTag("Manager").GetComponent<TreeBossStatus>();

        //getting the empty location children and = them to locs since they represent the locs
        locs = new Transform[2] { transform.GetChild(1).transform, transform.GetChild(2).transform };
        //Debug.Log(locs[0].position + "------" + locs[1].position);
        //if the boss status is true (boss is active)
        if (_status.TreeStatus)
        {
            //foreach to loop through the possible locations
            foreach (Transform loc in locs)
            {
                //randomise to determine what % chance it has of spawning
                if (Random.Range(0, 101) <= 50)
                {
                    //start the delay spawn coroutine
                    StartCoroutine(delaySpawn(loc.position));
                }
            }
        }
    }
    //method to spawn the hail in a specific (one of three lanes) randomised location
    private void SpawnTree(Vector3 loc)
    {
        if (Random.Range(0, 101) <= 50)
        {
            //instatiate the prefab
            GameObject instance = Object.Instantiate(prefab1, loc, prefab1.transform.rotation);
            //Debug.Log(instance.transform.position);
        }
        else
        {
            //instatiate the prefab
            GameObject instance = Object.Instantiate(prefab2, loc, prefab2.transform.rotation);
            //Debug.Log(instance.transform.position);
        }
        
    }
    //dealy spawn coroutine so that the hail doesnt spawn too slowly
    //now it spawns close to player
    IEnumerator delaySpawn(Vector3 loc)
    {
        //wait 8 seconds
        yield return new WaitForSeconds(8f);
        //spawn hail in a location
        SpawnTree(loc);
    }

}
