using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    private GameObject bulletPrefab;
    public Animator animator;
    public Manager manager;

    private void Start() {
        manager = GetComponent<Manager>();
        ChangeBullet(manager.skin);
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Q) && (manager.Mana > 0))
        {
            animator.SetTrigger("Shoot");
        }
    }

    public void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void ShootButton()
    {
        if (manager.Mana > 0)
        {
        animator.SetTrigger("Shoot");
        }
    }

    public void ChangeBullet(int i) {
        if (i == 0) {
            bulletPrefab = bulletPrefab1;
        } 
        else if (i == 1) { 
            bulletPrefab = bulletPrefab2;
        }
        else if (i == 2){
            bulletPrefab = bulletPrefab3;
        }
    }

    // public void AmmoLosev2() {
    //     manager.ammoLose();
    // }

}
