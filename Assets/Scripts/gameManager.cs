using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //A list for all the missile spawn points
    public Transform[] spawnPoints;

    //A game object for the missile prefab
    public GameObject missile;
    //Refrence to the time script
    public GameObject timeIncrease;

    //The missile's spawn period
    public float missileSpawnPeriod;

    //A random time that gets added to the spawn period
    private int randomTime;


    //Starts at the begining
    void Start()
    {
        //Assigns the timer
        timeIncrease = GameObject.Find("TimerIncrease");
        //Gets the speed from the time script
        missileSpawnPeriod = timeIncrease.GetComponent<timerScript>().missileSpawnPeriodTime;
        //Starts the coroutine that spawns the missile
        StartCoroutine(SpawnMissile());
        //Help
    }

    void Update()
    {
        
    }

    //Coroutine for spawning the missile
    IEnumerator SpawnMissile()
    {
        //Picks a random time that will be added to the spawn time of the missiles
        randomTime = Random.Range(0, 6);
        //Combines the spawn time and the randomized time
        float newTime = missileSpawnPeriod + randomTime;
        //Waits for the assigned amount of time
        yield return new WaitForSeconds(newTime);
        //Picks a random spawn point for the missile
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //Spawns in a missile
        Instantiate(missile, _sp.position, _sp.rotation);
        //Starts the coroutine again
        StartCoroutine(SpawnMissile());
    }
}
