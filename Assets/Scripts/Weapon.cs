﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public Manager manager;

    private void Start() {
        manager = GetComponent<Manager>();
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Q) && (manager.ammo > 0))
        {
            animator.SetTrigger("Shoot");
            manager.ammoLose();
        }
    }

    public void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void ShootButton()
    {
        if (manager.ammo > 0)
        {
        animator.SetTrigger("Shoot");
        manager.ammoLose();
        }
    }

}
