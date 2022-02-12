using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : Enemy
{
    private Collider2D coll;

    [SerializeField] private LayerMask Ground;

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght = 5f;
    [SerializeField] private float jumpHeight = 7f;
    

    protected override void Start() {
        base.Start();
        coll = GetComponent<Collider2D>();

    }
    private bool facingLeft = true;

    private void Update()
    {
        if (anim.GetBool("Jumping")) {
            if (rb.velocity.y < .2f) {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }
        if (coll.IsTouchingLayers(Ground) && anim.GetBool("Falling")) {
            anim.SetBool("Falling", false);
        }
    }

    private void Move()
    {
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
                    rb.velocity = new Vector2(-jumpLenght, jumpHeight);
                    anim.SetBool("Jumping", true);

                }
                else {

                }
            }
            else
            {
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
                    rb.velocity = new Vector2(jumpLenght, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    } 
}
