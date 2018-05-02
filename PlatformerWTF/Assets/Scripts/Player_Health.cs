using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    private int health = GlobalSetings.HP.Value;
    private InterfaceBattle interfaceBattle;

    // Use this for initialization
    void Start () {
        
        interfaceBattle = GameObject.Find("InterfaceBattle").GetComponent<InterfaceBattle>();
        interfaceBattle.ChangeHp(health);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddDamage(int i)
    {
        health -= i;
        
        interfaceBattle.ChangeHp(health);
        if (health <= 0)
        {
            Die();
        }
    }


}
