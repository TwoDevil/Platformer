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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.collider.gameObject.tag == "Player" && hit.distance < 0.6f)
        {
            if (XMoveDirection < 0)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.left+Vector2.up/2) * 1000);
            }
            else
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.right + Vector2.up / 2) * 1000);
            }
            hit.collider.gameObject.GetComponent<Player_Health>().AddDamage(10);
        }
        else
        {
            if (hit.distance < 0.6f)
            {
                Flip();
            }
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
