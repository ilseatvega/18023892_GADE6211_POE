using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowObsSpawn : MonoBehaviour
{
    //holds the 3 obs prefabs
    public GameObject[] items;
    //locations, holds the 3 different lane locs
    int[] locs = new int[3];
    //safezone - no objects spaw in this area
    public float safeZone = 60f;

    // Start is called before the first frame update
    void Start()
    {
        IceBossStatus referenceIce = GameObject.FindGameObjectWithTag("Manager").GetComponent<IceBossStatus>();
        //if status of boss is true (active)
        if (referenceIce.IceStatus == true)
        {
            //dont do anything
            return;
        }

        //new gameobj spawning - an instantiation of one of the objects or pickups
        GameObject spawning;

        if (this.transform.position.z > safeZone)
        {
            //for loop to loop through the possible locations and objects
            //not sure why some objects still spawn in one another even though pickups and obstacles use the same switch?
            //seems to only be pickups spawning in obstacles (not obstacle spawning on obsctacle for eg)
            for (int i = 0; i < locs.Length; i++)
            {
                //random range - the bigger the no. the less likely something will spawn
                locs[i] = Random.Range(0, 15);
                //switch that determines which object will spawn and where, if it's not one of the cases nothing will spawn
                switch (locs[i])
                {
                    //obstacles spawning
                    case 5:
                        //FENCE spawns 
                        spawning = Object.Instantiate(items[0], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    case 6:
                        //ROCK spawns
                        spawning = Object.Instantiate(items[1], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    case 7:
                        //HOLE spawns
                        spawning = Object.Instantiate(items[2], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;

                    //pickup item spawning
                    case 10:
                        //COIN spawns
                        //another random for each indvidual object to determine whether they will spawn - rare objects spawn less
                        if (Random.Range(0, 100) <= 100)
                        {
                            spawning = Object.Instantiate(items[3], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), items[3].transform.rotation);
                            spawning.transform.SetParent(this.transform);
                        }
                        break;

                    case 11:
                        //BLUEBERRY spawns
                        if (Random.Range(0, 100) <= 20)
                        {
                            spawning = Object.Instantiate(items[4], new Vector3((i * 10) - 10, this.transform.position.y + 4.5f, this.transform.position.z), items[4].transform.rotation);
                            spawning.transform.SetParent(this.transform);

                        }
                        break;
                    case 12:
                        //MAGNET spawns
                        if (Random.Range(0, 100) <= 30)
                        {
                            spawning = Object.Instantiate(items[5], new Vector3((i * 10) - 10, this.transform.position.y - 2f, this.transform.position.z), items[5].transform.rotation);
                            spawning.transform.SetParent(this.transform);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
