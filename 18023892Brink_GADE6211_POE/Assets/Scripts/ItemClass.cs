using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    //holds the 3 items prefabs ( only have 1 for now)
    public GameObject[] items;
    //locations, holds the 3 different lane locs
    int[] locs = new int[3];
    //safezone - no objects spaw in this area
    public float safeZone = 60f;

    // Start is called before the first frame update
    void Start()
    {
        //new gameobj spawning - an instantiation of one of the 3 obs
        GameObject spawning;

        //only spawn if outside the safe zone 
        if (this.transform.position.z > safeZone)
        {
            //for loop to loop through the possible locations and objects
            for (int i = 0; i < locs.Length; i++)
            {
                //random range - the bigger the no. the less likely something will spawn
                locs[i] = Random.Range(0, 20);
                //switch that determines which object will spawn and where, if it's not 7,8,9 nothing will spawn
                switch (locs[i])
                {
                    case 7:
                        //item 0 spawns
                        if (Random.Range(0, 100) <= 100)
                        {
                            spawning = Object.Instantiate(items[0], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), items[0].transform.rotation);
                            spawning.transform.SetParent(this.transform);
                            Debug.Log("case0");
                        }
                        break;

                    case 8:
                        //item 1 spawns
                        if (Random.Range(0, 100) <= 40)
                        {
                            spawning = Object.Instantiate(items[1], new Vector3((i * 10) - 10, this.transform.position.y + 5f, this.transform.position.z), items[1].transform.rotation);
                            spawning.transform.SetParent(this.transform);
                            Debug.Log("case1");
                        }
                        break;
                    case 9:
                        //item 3 spawns
                        if (Random.Range(0, 100) <= 50)
                        {
                            spawning = Object.Instantiate(items[2], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), items[2].transform.rotation);
                            spawning.transform.SetParent(this.transform);
                            Debug.Log("case2");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
