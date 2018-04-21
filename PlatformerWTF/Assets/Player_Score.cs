using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour {
    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Осталось времени: " + (int)timeLeft);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene("Prototype_1");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            CountScore(100);
            Destroy(collision.gameObject);
        }

    }
    private void CountScore(int score=0)
    {
        playerScore += score;
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Счет: " + playerScore);
    }

}
