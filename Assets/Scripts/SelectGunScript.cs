using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Concurrent;

public class SelectGunScript : MonoBehaviour
{
    public GameObject car;
    public GameObject normalGun;
    public GameObject miniGun;
    public GameObject rocketGun;

    public GameObject blackBox;

    public GameObject mainCanvas;

    public GameObject plane;

    public AudioSource musicBox;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void SelectedNormalGun()
    {
        normalGun.SetActive(true);

        car.GetComponent<carController>().isNormalGun = true;

        Destroy(blackBox);

        mainCanvas.SetActive(true);

        plane.GetComponent<Animator>().enabled = true;

        musicBox.Play(0);

        Time.timeScale = 1f;
    }
    public void SelectedMiniGun()
    {
        miniGun.SetActive(true);

        car.GetComponent<carController>().isMiniGun = true;

        Destroy(blackBox);

        mainCanvas.SetActive(true);

        plane.GetComponent<Animator>().enabled = true;

        musicBox.Play(0);

        Time.timeScale = 1f;
    }
    public void SelectedRocketGun()
    {
        rocketGun.SetActive(true);

        car.GetComponent<carController>().isRocketGun = true;

        Destroy(blackBox);

        mainCanvas.SetActive(true);

        plane.GetComponent<Animator>().enabled = true;

        musicBox.Play(0);

        Time.timeScale = 1f;
    }
}
