using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    //A position for something the missile needs to follow
    public Transform objectToFollow;

    //Speed of the missile
    public float speed;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            //Destroys the missile
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the missile move towards the car
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, speed * Time.deltaTime);
        //Makes the missile look at the car
        transform.LookAt(objectToFollow.transform.position);
    }
}
