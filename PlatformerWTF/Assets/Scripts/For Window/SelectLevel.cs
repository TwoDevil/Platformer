using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectLevel : MonoBehaviour {

    // Use this for initialization
    public void Level_1()
    {
        SceneManager.LoadScene("Dima_scene");
    }
    public void Level_2()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Level_3()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void Level_4()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Level_5()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Level_B()
    {
        SceneManager.LoadScene("LevelSelect");
    }


}
