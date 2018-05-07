using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour {

    private int health = 200;
    private InterfaceBattle interfaceBattle;

    // Use this for initialization
    void Start()
    {
        interfaceBattle = GameObject.Find("InterfaceBattle").GetComponent<InterfaceBattle>();
    }
    public void AddDamage(int i)
    {
        health -= i;

        interfaceBattle.ChangeHpBoss(health);
        if (health <= 0)
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
