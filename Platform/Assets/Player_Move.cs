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

    public bool isGround;
    public bool isJumpFirst;

    void Start()
    {
        isGround = true;
        isJumpFirst = true;
           playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }


	// Update is called once per frame
	void Update () {
        PlyerMove();
        PlayerRayCast();

    }

     void PlyerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            if(isGround|| isJumpFirst)
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        if (isGround)
        {
            isGround = false;
        }
        else if(isJumpFirst)
        {
            isJumpFirst = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Player has collided with " + collision.collider.name);
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGround = true;
            isJumpFirst = true;
        }
    }
    
    void PlayerRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider!=null)
        {
            //Debug.Log(hit.collider.gameObject.tag);
            if (hit.distance < 1.3f && hit.collider.gameObject.tag == "Enemy")
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
                isGround = true;
                isJumpFirst = true;
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
