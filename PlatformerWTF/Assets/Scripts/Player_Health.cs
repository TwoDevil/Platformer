using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    public int health = 100;
    public GameObject HealthBar;
    Sprite[] AllHealthBar;
    
    // Use this for initialization
    void Start () {
        AllHealthBar = Resources.LoadAll<Sprite>("Health_bar");
        ChangeHp();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
	}
    void Die()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void AddDamage(int i)
    {
        health -= i;
        ChangeHp();
        if (health <= 0)
        {
            Die();
        }
    }
    public void ChangeHp()
    {

        if (health >= 100)
        {
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[0];
        }
        else if(health <=0)
        {
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[11];
        }
        else
        {
            HealthBar.GetComponent<SpriteRenderer>().sprite = AllHealthBar[Mathf.Abs(health / 10 - 11)];
        }
    }

}
