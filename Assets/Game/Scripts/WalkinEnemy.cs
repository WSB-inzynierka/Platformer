using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkinEnemy : Enemy
{
    private Collider2D coll;

    [SerializeField] private LayerMask Ground;
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float speed;

    public float knockback;
    public bool groundCheck;
    

    protected override void Start() {
        base.Start();
        coll = GetComponent<Collider2D>();

    }
    private bool facingLeft = true;

    private void Update()
    {
        Move();
        
        // if(groundCheck) {
        //     if (transform.position.x > leftCap)
        //     {
        //         if (transform.localScale.x != 1)
        //         {
        //             transform.localScale = new Vector3(1, 1, 1);
        //             hpBarObject.transform.localScale = new Vector3(1, 1, 1);
                    
        //         rb.velocity = new Vector2(speed, rb.velocity.y);
        //         }
        //     }
        //     else if (transform.position.x < rightCap)
        //     {
        //         if (transform.localScale.x != -1)
        //         {
        //             transform.localScale = new Vector3(-1, 1, 1);
        //             hpBarObject.transform.localScale = new Vector3(-1, 1, 1);
                    
        //         rb.velocity = new Vector2(-speed, rb.velocity.y);
        //         }
        //     }
        //     else {
        //         rb.velocity = new Vector2(knockback, rb.velocity.y);
        //     }

        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Projectile"))
        {
            Debug.Log("Ok");
            if(collision.gameObject.transform.position.x < transform.position.x)
            {
                knockback = 1;
            }
            else
            {
                knockback = -1;
            }
            rb.velocity = new Vector2(speed, 10);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
        {
            groundCheck = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
        {
            groundCheck = false;
        }
    }


    private void Move()
    {
        if (groundCheck){
            if (facingLeft)
            {
                if (transform.position.x > leftCap)
                {
                    if (transform.localScale.x != 1)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        hpBarObject.transform.localScale = new Vector3(1, 1, 1);
                    }

                    if (coll.IsTouchingLayers(Ground))
                    {
                        rb.velocity = new Vector2(-speed, rb.velocity.y);
                    }
                }
                else
                {
                    rb.velocity = new Vector2(knockback, rb.velocity.y);
                    facingLeft = false;
                }
            }

            else
            {
                if (transform.position.x < rightCap)
                {
                    if (transform.localScale.x != -1)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        hpBarObject.transform.localScale = new Vector3(-1, 1, 1);
                    }

                    if (coll.IsTouchingLayers(Ground))
                    {
                        rb.velocity = new Vector2(speed, rb.velocity.y);
                    }


                }
                else
                {
                    rb.velocity = new Vector2(knockback, rb.velocity.y);
                    facingLeft = true;
                }
            }
        }
    }
}