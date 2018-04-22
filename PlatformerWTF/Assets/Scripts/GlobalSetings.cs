using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills{
    public int CurentSkillLevel;
    public int MaxSkillLevel;
    public int Value;
    string SkillName;

}
public class GlobalSetings : MonoBehaviour {

    public static bool EnableGlobalFonMusic;
    public static bool EnableGlobalEffectMusic;
    public static int Level;
    public static int CurentNumber;
    public static Skills Jump;
    public static Skills Money;
    public static Skills Damage;
    public static Skills HP;
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
