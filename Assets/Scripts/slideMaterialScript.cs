using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideMaterialScript : MonoBehaviour
{
    //The speed that the material scrolls at
    public float scrollSpeed = 1f;

    //The refrence to the timer
    public GameObject timeIncrease;

    //The renderer
    Renderer rend;

    //Plays at start
    void Start()
    {
        //Gets the renderer
        rend = GetComponent<Renderer>();
    }

    //Update is triggered every frame
    void Update()
    {
        //Assigns the scroll speed
        scrollSpeed = timeIncrease.GetComponent<timerScript>().materialSlideSpeed;

        //This code here below makes the material slide. Very detailed description, I know lol
        float offset = Time.time * scrollSpeed;
        
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
