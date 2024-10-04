using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAnimation : MonoBehaviour
{
    public GameObject menu;

    public AudioSource musicBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(4.3f);
        menu.SetActive(true);
        musicBox.Play(0);
    }
}
