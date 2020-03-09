using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawn : MonoBehaviour
{
    public GameObject[] obstacles;

    int[] locs = new int[3];

    public float safeZone = 60f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawning;
        if (this.transform.position.z > safeZone)
        {
            for (int i = 0; i < locs.Length; i++)
            {
                locs[i] = Random.Range(0, 10);
                switch (locs[i])
                {
                    case 3:
                        spawning = Object.Instantiate(obstacles[0], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    case 4:
                        spawning = Object.Instantiate(obstacles[1], new Vector3((i * 10) - 10, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        spawning.transform.SetParent(this.transform);
                        break;
                    case 5:
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
