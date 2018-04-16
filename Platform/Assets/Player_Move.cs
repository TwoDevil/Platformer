using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public int playerSpeed=10;
   private bool facingRight=false;
    public int playerJumpPower=300;
    private float moveX;
    public Rigidbody2D playerRigidbody;
	
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }


	// Update is called once per frame
	void Update () {
        PlyerMove();
	}

     void PlyerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //animation
        //player direction
        if(moveX<0.0f && facingRight==false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //phisics
        playerRigidbody.velocity = new Vector2(moveX * playerSpeed, playerRigidbody.velocity.y);
    }

     void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        //jumping
        GetComponent<Rigidbody2D>().AddForce(Vector2.up*playerJumpPower );
    }
}
