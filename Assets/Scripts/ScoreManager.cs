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
    private void Start()
    {
        GetComponent<timerScript>();
        missilesDestroyedText.text = "Missiles destroyed: " + missilesDestroyed;

        missilesDestroyedHiScore = PlayerPrefs.GetInt("HighScore");
        missilesDestroyedHiScoreText.text = "High Score: " + missilesDestroyedHiScore + " missiles destroyed!";
    }
 
}
