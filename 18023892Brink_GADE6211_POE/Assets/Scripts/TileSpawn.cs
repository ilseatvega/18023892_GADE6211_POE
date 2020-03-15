using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    //holds prefabs
    public GameObject prefab;
    //so i can track the transform of the player
    private Transform playerTrans;
    //float that holds the z spawn location
    private float spawnZ = 0.0f;
    //the length of one tile
    private float tileLength = 20.0f;
    //tiles that will be visible by the player on screen - made public so i can tweak it in inspector
    public int visTiles = 0;

    // Start is called before the first frame update
    void Start()
    {
        //finding the transform of the player and setting it to the transform i declared at the top
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        //basically just spawns all the starting vistiles at the start 
        //for as long as i is smaller than vistiles
        for (int i = 0; i < visTiles; i++)
        {
            //then spawn a tile
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the tiles that the player sees (spawnZ - visTiles * tileLength) 
        //is less than the player pos (playerTrans.position.z) then spawn more tiles
        if (playerTrans.position.z > (spawnZ - visTiles * tileLength))
        {
            //then spawn the tile
            SpawnTile();
        }
    }

    //method to spawn the tiles
    private void SpawnTile()
    {
        //declaring a gameobject called field
        GameObject field;
        //instantiating the field 
        field = Instantiate(prefab) as GameObject;
        //the position of the field is moved forward to the next spawnz
        field.transform.position = Vector3.forward * spawnZ;
        //the z spawn is now equal to the zspawn of the previous tile and the tile length in order
        spawnZ += tileLength;
    }
}
