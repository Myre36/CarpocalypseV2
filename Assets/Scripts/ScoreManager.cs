using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int startMinutes;
    public int highScoreMinutes;
    public TMP_Text currentTimeText;
    public TMP_Text currentTimeHiScoreText;
    
    


    public TMP_Text missilesDestroyedText;
    public TMP_Text missilesDestroyedHiScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreMinutes = PlayerPrefs.GetInt("HighScore: ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startMinutes > highScoreMinutes)
        {
            highScoreMinutes = startMinutes;
            PlayerPrefs.SetInt("HighScore", highScoreMinutes);
        }

        currentTimeText.text = "Score: " + startMinutes;
        currentTimeHiScoreText.text = "Hi-Score: " + highScoreMinutes;
    }
}
