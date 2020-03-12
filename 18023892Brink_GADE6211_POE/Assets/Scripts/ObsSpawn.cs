using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawn : MonoBehaviour
{
    //holds the 3 obs prefabs
    public GameObject[] obstacles;
    //locations, holds the 3 different lane locs
    int[] locs = new int[3];
    //safezone - no objects spaw in this area
    public float safeZone = 60f;

    // Start is called before the first frame update
    void Start()
    {
        //new gameobj spawning - an instantiation of one of the 3 obs
        GameObject spawning;
        if (this.transform.position.z > safeZone)
        {
            //for loop to loop through the possible locations and objects
            for (int i = 0; i < locs.Length; i++)
            {
                //random range - the bigger the no. the less likely something will spawn
                locs[i] = Random.Range(0, 15);
                //switch that determines which object will spawn and where, if it's not 3,4,5 nothing will spawn
                switch (locs[i])
                {
                    case 3:
                        //obstacles 0 spawns 
                        spawning = Object.Instantiate(obstacles[0], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    case 4:
                        //obstacle 1 spawns
                        spawning = Object.Instantiate(obstacles[1], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    case 5:
                        //obstacle 3 spawns
                        spawning = Object.Instantiate(obstacles[2], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
