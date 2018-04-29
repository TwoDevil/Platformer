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
    Sprite[] AllHealthBar;


    // Use this for initialization
    void Start () {
        timeLeft = 120;
        AllHealthBar = Resources.LoadAll<Sprite>("Health_bar");
        UpdateScore();
    }
    public void UpdateScore()
    {
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + GlobalSetings.CountScore);
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
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[Mathf.Abs(health / GlobalSetings.HP.Value * 10 - 11)];
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
