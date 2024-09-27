using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text currentTimeText;
    public TMP_Text currentTimeHiScoreText;
    public int startMinutes;
    


    public TMP_Text missilesDestroyedText;
    public TMP_Text missilesDestroyedHiScoreText;
    
    public static int scoreCount;
    public static int hiScoreCount;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore: ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
        }

        currentTimeText.text = "Score: " + scoreCount;
        currentTimeHiScoreText.text = "Hi-Score: " + hiScoreCount;
    }
}
