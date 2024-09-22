using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTerrain : MonoBehaviour
{
    //The position that the terrain moves towards
    public Transform target;
    //The position of the spawning terrain
    public Transform terrainSpawn;

    //The speed of the enviorment
    public float speed = 50f;

    //Refrence to the time script
    public GameObject timeIncrease;

    // Update is called once per frame
    void Update()
    {
        //Assigns the speed
        speed = timeIncrease.GetComponent<timerScript>().terrainSpeed;

        //Honestly dunno lol
        var step = speed * Time.deltaTime;
        //Makes the enviorment move towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //If the enviorment has reached the target
        if (Vector3.Distance(transform.transform.position, target.transform.position) < 1f)
        {
            //Teleport the terrain to the spawn
            this.gameObject.transform.position = terrainSpawn.position;
        }
    }
}
