using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills{

    public int CurentSkillLevel { get; set; }
    public int MaxSkillLevel { get; set; }
    public int Value { get; set; }
    public int UpValue { get; set; }
    public string SkillName { get; set; }
    public bool UpLevel()
    {
        if (CurentSkillLevel >= MaxSkillLevel || GlobalSetings.CurentNumberPoint<=0)
        {
            return false;
        }
        else
        {
            GlobalSetings.CurentNumberPoint--;
            CurentSkillLevel++;
            Value += UpValue;
            return true;
        }
    }
}
public class GlobalSetings : MonoBehaviour {

    public static bool EnableGlobalFonMusic { get; set; }
    public static bool EnableGlobalEffectMusic { get; set; }
    public static int Level { get; set; }
    public static int CurentNumberPoint { get; set; }

    public static Skills Jump { get; set; }
    public static Skills Money { get; set; }
    public static Skills Damage { get; set; }
    public static Skills HP { get; set; }
    // Use this for initialization
    static GlobalSetings()
    {
        HP = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 10, Value = 100, UpValue = 10, SkillName = "Жизни. Увеличьте количество ХП" };
        Damage = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 10, Value = 10, UpValue = 2, SkillName = "Урон. Увеличьте ваш урон" };
        Money = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 10, Value = 100, UpValue = 10, SkillName = "Деньги. Увеличьте прирост денег" };
        Jump = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 10, Value = 600, UpValue = 50, SkillName = "Прыжок. Увеличьте высоту прыжка" };
        Level = 10;
        CurentNumberPoint = 10;
    }
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
