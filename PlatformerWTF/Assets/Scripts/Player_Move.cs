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
    Vector2 fwd;



    void Start()
    {
        Debug.Log(GlobalSetings.Jump.Value);
        isGround = true;
        isJumpFirst = true;
        animator = this.GetComponent<Animator>();
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
       // animator.SetTrigger("attack");
        playerColl = GetComponent<BoxCollider2D>();
        fwd = transform.TransformDirection(Vector2.right);//Для атаки
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



    

    void HandleAttack()
    {
        if(attack)
        {
            animator.SetTrigger("attack");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, fwd, 1.3f);
            if (hit.collider != null && hit.collider.name == "Enemy")
            {
               
                Destroy(hit.collider.gameObject);
            }
            RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), fwd, 1.3f);
            if (hit1.collider != null && hit1.collider.name == "Enemy")
            {

                Destroy(hit1.collider.gameObject);
            }
            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1f), fwd, 1.3f);
            if (hit2.collider != null && hit2.collider.name == "Enemy")
            {

                Destroy(hit2.collider.gameObject);
            }
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

    void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y), fwd, 1f);
        if (hit.collider != null && hit.collider.name == "Ground" && isGround == false)
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), fwd, 1f);
        if (hit1.collider != null && hit1.collider.name == "Ground" && isGround == false)
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1f), fwd, 1f);
        if (hit2.collider != null && hit2.collider.name == "Ground" && isGround==false)
        {
            playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
        }

        //Debug.DrawLine(transform.position, new Vector3(1,0,0), Color.red, 2f, false);
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
            fwd = transform.TransformDirection(Vector2.left);


        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            fwd = transform.TransformDirection(Vector2.right);
          

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



        //атака
        //a = animator.GetCurrentAnimatorStateInfo(0);
        ////Debug.Log("Player has collided with " + a.IsName("KnightAttack"));
        //if (collision.collider.gameObject.tag == "Enemy" && a.IsName("KnightAttack"))
        //{
        //    Destroy(collision.collider.gameObject);
        //}
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
