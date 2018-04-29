using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills{

    public int CurentSkillLevel { get; set; }
    public int MaxSkillLevel { get; set; }
    public int Value { get; set; }
    public int UpValue { get; set; }
    public string SkillName { get; set; }
    public int CountValue { get; set; }
    public int CountValueUp { get; set; }
    public bool UpLevel()
    {
        if (CurentSkillLevel >= MaxSkillLevel || GlobalSetings.CountScore < CountValue)
        {
            return false;
        }
        else
        {
            GlobalSetings.CountScore-= CountValue;
            CurentSkillLevel++;
            Value += UpValue;
            CountValue += CountValueUp;
            return true;
        }
    }
}


public class GlobalSetings : MonoBehaviour {

    public static bool EnableGlobalFonMusic { get; set; }
    public static bool EnableGlobalEffectMusic { get; set; }

    public static int CountScore { get; set; }
    public static Skills Jump { get; set; }
    public static Skills Money { get; set; }
    public static Skills Damage { get; set; }
    public static Skills HP { get; set; }
    // Use this for initialization
    static GlobalSetings()
    {
        HP = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 10, Value = 100, UpValue = 10, CountValue=100, CountValueUp=100, SkillName = "Жизни. Увеличьте количество ХП" };
        Damage = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 10, Value = 10, UpValue = 2, CountValue = 300, CountValueUp = 300, SkillName = "Урон. Увеличьте ваш урон" };
        Money = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 20, Value = 100, UpValue = 10, CountValue = 100, CountValueUp = 100, SkillName = "Деньги. Увеличьте прирост денег" };
        Jump = new Skills() { CurentSkillLevel = 0, MaxSkillLevel = 20, Value = 500, UpValue = 25, CountValue = 100, CountValueUp = 50, SkillName = "Прыжок. Увеличьте высоту прыжка" };
        //DataManagement.datamanagement.LoadData();
        CountScore = 1000;
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
