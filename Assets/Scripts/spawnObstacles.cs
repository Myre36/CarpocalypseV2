using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    //List for the spawn points
    public Transform[] spawnPoints;

    //List for the obstacles
    public GameObject[] obstacles;
    //Refrence to the timer 
    public GameObject timeIncrease;
    public GameObject scrap;

    //The spawn period of the obstacles
    public float obstacleSpawnPeriod = 1.0f;

    //Bools for if each spawn position is safe
    private bool spawnOneSafe;
    private bool spawnTwoSafe;
    private bool spawnThreeSafe;
    private bool spawnFourSafe;

    void Start()
    {
        //Calls in a function to restart all the bools
        RestartBools();
        //Starts the coroutine that spawns in the obstacles
        StartCoroutine(SpawnRandomObstacle());
    }

    void Update()
    {
        //Assigns the obstacle spawn period
        obstacleSpawnPeriod = timeIncrease.GetComponent<timerScript>().obstacleSpawnPeriod;
    }

    //I'm very solrry TO for all the code in this script
    //A function that picks a random spawn point. That spawn point will be safe
    void PickSafePoint()
    {
        int safeNumber = Random.Range(0, 5);
        if (safeNumber == 0)
        {
            spawnOneSafe = true;
        }
        else if (safeNumber == 1)
        {
            spawnTwoSafe = true;
        }
        else if (safeNumber == 2)
        {
            spawnThreeSafe = true;
        }
        else
        {
            spawnFourSafe = true;
        }
    }

    //A function for restarting all the bools
    void RestartBools()
    {
        spawnOneSafe = false;
        spawnTwoSafe = false;
        spawnThreeSafe = false;
        spawnFourSafe = false;
    }

    //The next few functions spawn in stuff at the spawn positions
    void SpawnPoint1()
    {
        GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
        Vector3 spawnRotation;
        if (randomObstacle == obstacles[1])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 270f), 0f);
        }
        else if (randomObstacle == obstacles[4])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 180f), 0f);
        }
        else
        {
            spawnRotation = new Vector3(0f, 0f, 0f);
        }
        if (spawnOneSafe == true)
        {
            Instantiate(obstacles[0], spawnPoints[0].transform.position, Quaternion.Euler(spawnRotation));
        }
        else
        {
            Instantiate(randomObstacle, spawnPoints[0].transform.position, Quaternion.Euler(spawnRotation));
        }
    }

    void SpawnPoint2()
    {
        GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
        Vector3 spawnRotation;
        if (randomObstacle == obstacles[1])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 270f), 0f);
        }
        else if (randomObstacle == obstacles[4])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 180f), 0f);
        }
        else
        {
            spawnRotation = new Vector3(0f, 0f, 0f);
        }
        if (spawnTwoSafe == true)
        {
            Instantiate(obstacles[0], spawnPoints[1].transform.position, Quaternion.Euler(spawnRotation));
        }
        else
        {
            Instantiate(randomObstacle, spawnPoints[1].transform.position, Quaternion.Euler(spawnRotation));
        }
    }

    void SpawnPoint3()
    {
        GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
        Vector3 spawnRotation;
        if (randomObstacle == obstacles[1])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 270f), 0f);
        }
        else if (randomObstacle == obstacles[4])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 180f), 0f);
        }
        else
        {
            spawnRotation = new Vector3(0f, 0f, 0f);
        }
        if (spawnThreeSafe == true)
        {
            Instantiate(obstacles[0], spawnPoints[2].transform.position, Quaternion.Euler(spawnRotation));
        }
        else
        {
            Instantiate(randomObstacle, spawnPoints[2].transform.position, Quaternion.Euler(spawnRotation));
        }
    }

    void SpawnPoint4()
    {
        GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
        Vector3 spawnRotation;
        if (randomObstacle == obstacles[1] || randomObstacle == obstacles[5] || randomObstacle == obstacles[6])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 360f), 0f);
        }
        else if (randomObstacle == obstacles[4])
        {
            spawnRotation = new Vector3(0f, Random.Range(0f, 180f), 0f);
        }
        else
        {
            spawnRotation = new Vector3(0f, 0f, 0f);
        }
        if (spawnFourSafe == true)
        {
            Instantiate(obstacles[0], spawnPoints[3].transform.position, Quaternion.Euler(spawnRotation));
        }
        else
        {
            Instantiate(randomObstacle, spawnPoints[3].transform.position, Quaternion.Euler(spawnRotation));
        }
    }
    //End of spawning code

    //Coroutine for spawning the obstacles
    IEnumerator SpawnRandomObstacle()
    {
        //Picks a random spawn point to be guarenteed safe
        PickSafePoint();
        //Waits for 0.1 second
        yield return new WaitForSeconds(0.1f);
        //Spawns in something at all the spawn points
        SpawnPoint1();
        SpawnPoint2();
        SpawnPoint3();
        SpawnPoint4();
        //Waits for the assigned spawn period
        yield return new WaitForSeconds(obstacleSpawnPeriod);
        //Restarts all the bools
        RestartBools();
        //Restarts the coroutine
        StartCoroutine(SpawnRandomObstacle());
    }
}
