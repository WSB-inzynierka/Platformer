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

    public HealthBar healthBar; //
    public HealthBar slider;
    public GameObject hpBarObject;

    protected virtual void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // 
        slider.gameObject.SetActive(false);
    }

    public void EnemyDeath() {
        anim.SetTrigger("Death");
        death.Play();
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("Enemy Die");

    }

    private void Death(){
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage) {

        currentHealth -= damage;

        slider.gameObject.SetActive(true);

        healthBar.SetHealth(currentHealth); //

        Debug.Log(currentHealth);
        DamageKnockBack();

        if (currentHealth <= 0) {
            EnemyDeath();
        }
    }

    public void DamageKnockBack() {
        
        if (this.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-4, 4);
                }
                else
                {
                    rb.velocity = new Vector2(4, 4);
                }
    }
}
