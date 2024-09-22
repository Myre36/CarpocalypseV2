using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    //Refrence to the car on the main menu
    public GameObject car;

    //Function to start animation that plays at the start of the game
    public void StartGame()
    {
        StartCoroutine(BeginAnimation());
    }
    //Function for exiting the tutorial
    public void ExitTutorial()
    {
        SceneManager.LoadScene("MainGameScene");
    }
    //Function for going back into the menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //A function that quits the game
    public void EndGame()
    {
        Application.Quit();
    }

    //A coroutine that plays the animation and then starts the game
    IEnumerator BeginAnimation()
    {
        //Starts playing the animation
        car.GetComponent<Animator>().Play("Burnout");
        //Waits for the animation to finish
        yield return new WaitForSeconds(5.3f);
        //Loads the tutorial
        SceneManager.LoadScene("TutorialScene");
    }
}
