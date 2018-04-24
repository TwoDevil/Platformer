using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SelectSkills {Jump,Count,Attack,HP };

public class UpgradeMenu : MonoBehaviour {
    Skills CurentSkill;
    public GameObject levelUpgrade;
    public GameObject bonusValue;
    public GameObject textSkills;
    public GameObject CurentPointLevel;
    public void SelectJump()
    {
        CurentSkill = GlobalSetings.Jump;
        SelectSkill();
    }
    public void SelectMoney()
    {
        CurentSkill = GlobalSetings.Money;
        SelectSkill();
    }
    public void SelectDamage()
    {
        CurentSkill = GlobalSetings.Damage;
        SelectSkill();
    }
    public void SelectHP()
    {
        CurentSkill = GlobalSetings.HP;
        SelectSkill();
    }
    public void SelectSkill()
    {
        levelUpgrade.gameObject.GetComponent<Text>().text = ("Уровень навыка: " + CurentSkill.CurentSkillLevel + " \\ " + CurentSkill.MaxSkillLevel);
        bonusValue.gameObject.GetComponent<Text>().text = ("Бонус уровня\\Текущее значение: " + CurentSkill.UpValue + " \\ " + CurentSkill.Value);
        textSkills.gameObject.GetComponent<Text>().text = ("Название навыка: " + CurentSkill.Value);
        CurentPointLevel.gameObject.GetComponent<Text>().text = ("Число свободных умений: " + GlobalSetings.CurentNumberPoint+ " \\ " + GlobalSetings.Level);
    }
    public void UpdateSkills()
    {
        if (CurentSkill.UpLevel())
        {
            SelectSkill();
        }
    }
    // Use this for initialization
    void Start () {
        SelectJump();
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
