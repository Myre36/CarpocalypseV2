using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class missileScript : MonoBehaviour
{
    //A position for something the missile needs to follow
    public GameObject objectToFollow;
    //A refrence to the black box that displays when a missile is fired
    public GameObject blackBox;
    //Refrence to the text that displays when a missile is fired
    public GameObject pressText;
    //Refrence to the time script
    public GameObject timeIncrease;

    //Speed of the missile
    public float speed;

    //The assigned number of the missile
    public int assignedNumber;

    // Start is called before the first frame update
    void Start()
    {
        //Assigns the timer
        timeIncrease = GameObject.Find("TimerIncrease");
        //Gets the speed from the time script
        speed = timeIncrease.GetComponent<timerScript>().missileSpeed;

        //Assigns a random number to the missile
        assignedNumber = Random.Range(1, 5);
        //Sets the car as the object to follow
        objectToFollow = GameObject.Find("Car");
        //Assigns the black box
        blackBox = GameObject.Find("BlackBox");
        //Assigns the press text
        pressText = GameObject.Find("PressText");
        //Enables the black box
        blackBox.GetComponent<Image>().enabled = true;
        //Enables the text
        pressText.GetComponent<TMP_Text>().enabled = true;
    }

    //If an object collides with the missile
    void OnCollisionEnter(Collision collision)
    {
        //If the object is a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Destroys the missile
            Destroy(gameObject);
            //Disables the black box
            blackBox.GetComponent<Image>().enabled = false;
            //Disables the text
            pressText.GetComponent<TMP_Text>().enabled = false;
            //Increases the number of missiles destroyed
            timeIncrease.GetComponent<timerScript>().missilesDestroyed++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the missile move towards the car
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, speed * Time.deltaTime);
        //Makes the missile look at the car
        transform.LookAt(objectToFollow.transform.position, Vector3.left);
    }
}
