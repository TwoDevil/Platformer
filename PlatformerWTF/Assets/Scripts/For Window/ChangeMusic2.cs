using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic2 : MonoBehaviour {

    void Start()
    {
        ProverMusic();
    }
    public void Change()
    {
        GlobalSetings.EnableGlobalEffectMusic = !GlobalSetings.EnableGlobalEffectMusic;
        ProverMusic();
    }
    private void ProverMusic()
    {
        if (GlobalSetings.EnableGlobalEffectMusic)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Music4");
        }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Music3");
        }
    }
}
