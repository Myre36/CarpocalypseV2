using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMissileScript : MonoBehaviour
{
    //The object that follows the first missile in the list
    public GameObject targetObject;
    //A list for all the missiles
    public GameObject[] allTargetsWithTag;

    // Update is called once per frame
    void Update()
    {
        //Fills the list with all gameobjects that have the tag "Missile"
        allTargetsWithTag = GameObject.FindGameObjectsWithTag("Missile");

        //Makes the targetObject follow the first missile in the list
        targetObject.transform.position = allTargetsWithTag[0].transform.position;
    }
}
