using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    //The speed which the obstacle moves at
    public float speed;

    //The obstacle's rigidbody
    public Rigidbody rb;

    //Refrence to the timer
    public GameObject timerIncrease;

    // Start is called before the first frame update
    void Start()
    {
        //Assigns the timer
        timerIncrease = GameObject.Find("TimerIncrease");
        //Assigns the speed
        speed = timerIncrease.GetComponent<timerScript>().obstacleSpeed;
        //Applies speed to the obstacle when it spawns in
        rb.velocity = new Vector3(0f, 0f, -speed);
    }

    //When an object collides with the obstacle
    void OnCollisionEnter(Collision collision)
    {
        //If the object is the obstacle endpoint
        if (collision.gameObject.CompareTag("ObstacleEndpoint"))
        {
            //Destroys the obstacle
            Destroy(gameObject);
        }
    }
}
