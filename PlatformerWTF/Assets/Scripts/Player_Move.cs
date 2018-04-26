using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public int playerSpeed=10;
    private bool facingRight=false;
    private float moveX;
    public Rigidbody2D playerRigidbody;
    public float distanceToBottomOfPlayer=1.3f;
    public bool isGround;
    public bool isJumpFirst;

    void Start()
    {
        Debug.Log(GlobalSetings.Jump.Value);
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

        if(moveX!=0)
        {
            GetComponent<Animator>().SetBool("IsRunning",true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        //player direction
        if(moveX<0.0f )
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //phisics
        playerRigidbody.velocity = new Vector2(moveX * playerSpeed, playerRigidbody.velocity.y);
    }

    // void FlipPlayer()
    //{
    //    facingRight = !facingRight;
    //    Vector2 localScale = gameObject.transform.localScale;
    //    localScale.x *= -1;
    //    transform.localScale = localScale;
    //}

    void Jump()
    {
        //jumping
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * GlobalSetings.Jump.Value);
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

        //Debug.Log("Player has collided with " + collision.gameObject.tag);
        //Debug.Log("Player has collided with " + collision.collider.name);
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGround = true;
            isJumpFirst = true;
        }
    }

    void PlayerRayCast()
    {
        //ray up
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "box2")
        {
            Destroy(rayUp.collider.gameObject);
        }

        //ray down
        RaycastHit2D rayDawn = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDawn.collider != null && rayDawn.distance < distanceToBottomOfPlayer && rayDawn.collider.gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
            rayDawn.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDawn.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDawn.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDawn.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDawn.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }
        if(rayDawn != null && rayDawn.collider != null && rayDawn.distance< distanceToBottomOfPlayer && rayDawn.collider.gameObject.tag == "Enemy")
        {
            isGround = true;
        }

      

    }
}
