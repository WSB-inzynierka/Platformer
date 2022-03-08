using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected AudioSource death;
    public int maxHealth = 100;
    public int currentHealth;
    public int enemyDamage;
    public GameObject CherryPrefab;
    public Transform firePoint;

    public HealthBar healthBar;
    public HealthBar slider;
    public GameObject hpBarObject;
    public bool groundCheck;


    protected virtual void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
        slider.gameObject.SetActive(false);
    }
    

    public void EnemyDeath() {
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        Instantiate(CherryPrefab, firePoint.position+ Vector3.left, firePoint.rotation);
        Instantiate(CherryPrefab, firePoint.position+ Vector3.right, firePoint.rotation);
        anim.SetTrigger("Death");
        death.Play();
    }

    private void Death(){
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage) {

        currentHealth -= damage;

        slider.gameObject.SetActive(true);

        healthBar.SetHealth(currentHealth);

        DamageKnockBack();

        if (currentHealth <= 0) {
            EnemyDeath();
        }
    }

    public void DamageKnockBack() {
        
        if (this.gameObject.transform.position.x > transform.position.x)
                {
                    //rb.AddForce(new Vector2(5, 5),ForceMode2D.Impulse);
                }
                else
                {
                    //rb.AddForce(new Vector2(-5, 5),ForceMode2D.Impulse);
                }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
        {
            groundCheck = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            groundCheck = false;
            rb.velocity = new Vector2(0,0);
            if (collision.transform.position.x < transform.position.x) {
                rb.AddForce(new Vector2(3,3), ForceMode2D.Impulse);
            }
            else if (collision.transform.position.x > transform.position.x) {
                rb.AddForce(new Vector2(-3,3), ForceMode2D.Impulse);
            }
        }

        if (collision.gameObject.tag == "Projectile")
        {
            groundCheck = false;
            rb.velocity = new Vector2(0,0);
            if (collision.transform.position.x < transform.position.x) {
                rb.AddForce(new Vector2(3,3), ForceMode2D.Impulse);
            }
            else if (collision.transform.position.x > transform.position.x) {
                rb.AddForce(new Vector2(-3,3), ForceMode2D.Impulse);
            }
        }
    }
}
