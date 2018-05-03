using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public  int playerSpeed=10;
    private bool facingRight=false;
    private float moveX;
    float imp = 0;
    public Rigidbody2D playerRigidbody;
    public float distanceToBottomOfPlayer=1.3f;
    public bool isGround;
    public bool isJumpFirst;
    bool attack;
    Animator animator;
    AnimatorStateInfo a;
    BoxCollider2D playerColl;



    void Start()
    {
        Debug.Log(GlobalSetings.Jump.Value);
        isGround = true;
        isJumpFirst = true;
        animator = this.GetComponent<Animator>();
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
       // animator.SetTrigger("attack");
        playerColl = GetComponent<BoxCollider2D>();
    }


	// Update is called once per frame
	void Update () {
       
        HandleAttack();
        ResetValues();
        PlyerMove();
        PlayerRayCast();
        HandleInput();
       // UpdateRay();
    }



    void UpdateRay()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    void HandleAttack()
    {
        if(attack)
        {
            animator.SetTrigger("attack");
        }
    }
    void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            attack = true;
            
           //playerColl.size= new Vector2(playerColl.offset.x+2,playerColl.offset.y);
            
        }
    }
    void PlyerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround || isJumpFirst)
                Jump();
        }


        //if(Input.GetKeyDown(KeyCode.X))
        //{
        //    animator.SetTrigger("attack");

        //}
        //animation

        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        //player direction
        if (moveX < 0.0f)
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

   void ResetValues()
    {
        attack = false;
        
        //playerColl.size = new Vector2(playerColl.offset.x - 2, playerColl.offset.y);
    }
    void Jump()
    {
        //jumping
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
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




        a = animator.GetCurrentAnimatorStateInfo(0);
        //Debug.Log("Player has collided with " + a.IsName("KnightAttack"));
        if (collision.collider.gameObject.tag == "Enemy" && a.IsName("KnightAttack"))
        {
            Destroy(collision.collider.gameObject);
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
        //if (rayDawn.collider != null && rayDawn.distance < distanceToBottomOfPlayer && rayDawn.collider.gameObject.tag == "Enemy")
        //{
        //    GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        //    rayDawn.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
        //    rayDawn.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
        //    rayDawn.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        //    rayDawn.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //    rayDawn.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        //}


        if (rayDawn != null && rayDawn.collider != null && rayDawn.distance < distanceToBottomOfPlayer && rayDawn.collider.gameObject.tag == "Enemy")
        {
            isGround = true;
        }



    }
}
