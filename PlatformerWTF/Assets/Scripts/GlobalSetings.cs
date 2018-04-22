using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetings : MonoBehaviour {

    public static bool EnableGlobalFonMusic;
    public static bool EnableGlobalEffectMusic;

    // Use this for initialization
    void Start () {
        MuteMusic();
    }
    public void MuteMusic()
    {
        if (EnableGlobalFonMusic)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
        }
    }


	
}
