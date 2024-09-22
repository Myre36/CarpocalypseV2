using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timerScript : MonoBehaviour
{
    //A bunch of values for the speed of everything in the game
    public float obstacleSpeed = 25f;

    public float obstacleDecreasePerRound;

    public float obstacleSpawnPeriod = 2f;

    public float obstacleSpawnIncrease;

    public float materialSlideSpeed = 1.25f;

    public float materialIncreasePerTurn;

    public float terrainSpeed = 25.5f;

    public float terrainIncreasePerTurn;

    public float missileSpeed = 20f;

    public float missileDecreasePerRound;

    public float timeBetweenIncrease;

    //A bunch of other variables
    bool stopWatchActive = false;
    float currentTime;
    public int startMinutes;
    public TMP_Text currentTimeText;

    public int missilesDestroyed;

    public TMP_Text missilesDestroyedText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes = 0;
        stopWatchActive = true;
        missilesDestroyed = 0;
        StartCoroutine(IncreaseSpeed());
    }

    void Update()
    {
        if (stopWatchActive == true)
        { 
            currentTime = currentTime + Time.deltaTime; 
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\.ff");
        missilesDestroyedText.text = "Missiles destroyed: " + missilesDestroyed;
    }

    public void StartStopWatch()
    { 
        stopWatchActive = true; 
    }

    public void StopStopWatch()
    { 
        stopWatchActive = false; 
    }

IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(timeBetweenIncrease);
        obstacleSpeed = obstacleSpeed + obstacleDecreasePerRound;
        obstacleSpawnPeriod = obstacleSpawnPeriod - obstacleSpawnIncrease;
        materialSlideSpeed = materialSlideSpeed + materialIncreasePerTurn;
        terrainSpeed = terrainSpeed + terrainIncreasePerTurn;
        missileSpeed = missileSpeed + missileDecreasePerRound;
        StartCoroutine(IncreaseSpeed());
    }
}
