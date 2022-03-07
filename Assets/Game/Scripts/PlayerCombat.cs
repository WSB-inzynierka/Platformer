using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public PlayerController playerController;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 5f;
    public bool attackbutton = false;

    float nextAttackTime = 0f;

    private void Update() {
        if (Time.time >= nextAttackTime)   {
            playerController.canMove = true;
            if (Input.GetKeyDown(KeyCode.E) || attackbutton) {
                attackbutton = false;
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
                playerController.canMove = false;
            }
        }
        else {
                playerController.canMove = false;
        }
    }

    public void Attack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void attack2() {
        attackbutton = true;
    }


    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
