using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class SettingMenu : MonoBehaviour {

    // Use this for initialization
    public void NewGame()
    {
        SceneManager.LoadScene("Dima_scene");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Info()
    {
        SceneManager.LoadScene("Upgrade");
    }
    public void Exit()
    {
        Exit();
    }
}
