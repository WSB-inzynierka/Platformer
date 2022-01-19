using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int arrowDamage = 60;
    public ParticleSystem impactEffect;

    public void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    public void OnTriggerEnter2D(Collider2D hitInfo) {
        
        if (hitInfo.gameObject.tag == "Enemy") {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            enemy.TakeDamage(arrowDamage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            impactEffect.Play(true);
        }
        if (hitInfo.gameObject.tag == "Ground") {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            impactEffect.Play(true);
        }
        
    }
}
