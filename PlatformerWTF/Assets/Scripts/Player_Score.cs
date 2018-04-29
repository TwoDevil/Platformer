using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Score : MonoBehaviour {

    private InterfaceBattle interfaceBattle;

    // Use this for initialization
    void Start () {
        interfaceBattle = GameObject.Find("InterfaceBattle").GetComponent<InterfaceBattle>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Coin")
    //    {
    //        CountScore(GlobalSetings.Money.Value);
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void CountScore(int score=0)
    {
        Debug.Log(DataManagement.datamanagement.highscore);
        GlobalSetings.CountScore += score;
        DataManagement.datamanagement.highscore = GlobalSetings.CountScore;
        DataManagement.datamanagement.SaveData();
        Debug.Log(DataManagement.datamanagement.highscore);
        interfaceBattle.UpdateScore();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag=="Coin")
        {
            CountScore(GlobalSetings.Money.Value);
            Destroy(trig.gameObject);
        }
        if (trig.gameObject.tag == "EndLevel")
        {
            CountScore((int)interfaceBattle.timeLeft * 100);
            DataManagement.datamanagement.SaveData();
        }
        Debug.Log("Touch end level");
    }
    

}
