using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public int missilesDestroyed;
    public TMP_Text missilesDestroyedText;
    public int missilesDestroyedHiScore;
    public TMP_Text missilesDestroyedHiScoreText;
    public void Start()
    {
        GetComponent<timerScript>();
        if (missilesDestroyed > PlayerPrefs.GetInt("Score"))
            {
            PlayerPrefs.SetInt("Score", missilesDestroyed);
        }// insert default value)
{
            
}
        missilesDestroyedText.text = "Missiles destroyed: " + missilesDestroyed;

        missilesDestroyedHiScore = PlayerPrefs.GetInt("HighScore");
        missilesDestroyedHiScoreText.text = "High Score: " + missilesDestroyedHiScore + " missiles destroyed!";
    }
 
}
