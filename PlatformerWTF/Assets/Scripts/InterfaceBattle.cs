using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InterfaceBattle : MonoBehaviour {
    public float timeLeft;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject HealthBar;
    public GameObject HealthBoss;
    Sprite[] AllHealthBar;


    // Use this for initialization
    void Start () {
        timeLeft = 120;
        AllHealthBar = Resources.LoadAll<Sprite>("Health_bar");
        UpdateScore();
    }
    public void UpdateScore()
    {
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Money: " + GlobalSetings.CountScore);
    }
    public void ChangeHp(int health)
    {

        if (health >= GlobalSetings.HP.Value)
        {
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[0];
        }
        else if (health <= 0)
        {
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[11];
        }
        else
        {
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[Mathf.Abs(health  * 10 / GlobalSetings.HP.Value - 11)];
        }
    }
    public void ChangeHpBoss(int health)
    {

        if (health >= 200)
        {
            HealthBoss.GetComponent<SpriteRenderer>().sprite = AllHealthBar[0];
        }
        else if (health <= 0)
        {
            HealthBoss.GetComponent<SpriteRenderer>().sprite = AllHealthBar[11];
        }
        else
        {
            HealthBoss.GetComponent<SpriteRenderer>().sprite = AllHealthBar[Mathf.Abs(health / 20 - 11)];
        }
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time left: " + (int)timeLeft);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
