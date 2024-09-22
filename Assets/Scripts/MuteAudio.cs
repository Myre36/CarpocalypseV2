using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    //Function for muting the audio
    public void MuteHandeler(bool mute)
    {
        //If it's muted
        if (mute)
        {
            //Set the audio to 0
            AudioListener.volume = 0;
        }
        //If it's not muted
        else
        {
            //Set the audio to 1
            AudioListener.volume = 1;
        }
    }
}
