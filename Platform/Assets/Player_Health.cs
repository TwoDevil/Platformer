using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    public int health = 100;
	// Use this for initialization
	void Start () {
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
        SceneManager.LoadScene("Prototype_1");
    }
    public void AddDamage(int i)
    {
        health -= i;
        if (health <= 0)
        {
            Die();
        }
    }

}
