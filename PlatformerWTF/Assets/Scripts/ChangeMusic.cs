using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        ProverMusic();
    }
    public void Change()
    {
        GlobalSetings.EnableGlobalFonMusic = !GlobalSetings.EnableGlobalFonMusic;
        ProverMusic();
    }
    private void ProverMusic()
    {
        if (GlobalSetings.EnableGlobalFonMusic)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Music2");
        }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Music1");
        }
    }

}
