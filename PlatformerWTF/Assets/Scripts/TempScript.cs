using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour {

    public float speed;
    private float pos;
    Renderer render;


	void Start()
    {
        render = GetComponent<Renderer>();
    }
	// Update is called once per frame
	void Update () {
        pos = +speed;
        render.material.mainTextureOffset = new Vector2(pos,0);
	}
}
