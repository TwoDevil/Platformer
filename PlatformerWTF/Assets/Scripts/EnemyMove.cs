using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        //if (hit.distance < 0.7f)
        //{
        //    Flip();
        //}
        ////if (hit.distance < 0.7f)
        ////{
        ////    Flip();
        ////    if (hit.collider.gameObject.tag == "Player")
        ////    {
        ////        Destroy(hit.collider.gameObject);
        ////    }
        ////}
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.collider.gameObject.tag == "Player" && hit.distance < 1f)
        {
            if (XMoveDirection < 0)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.left + Vector2.up / 2) * 500);
            }
            else
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.right + Vector2.up / 2) * 500);
            }
            hit.collider.gameObject.GetComponent<Player_Health>().AddDamage(10);
        }
        else
        {
            if (hit.distance < 1f)
            {
                Flip();
            }
        }

        if (gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
