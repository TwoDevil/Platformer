using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class SettingMenu : MonoBehaviour {

    // Use this for initialization
    public void NewGame()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Info()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        Exit();
    }
}
