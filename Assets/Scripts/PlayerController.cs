using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public Rigidbody2D rigidBody2D;

    private void Update() {

        if (Input.GetKey(KeyCode.A)) {
            rigidBody2D.velocity = new Vector2(-5, 0);
        }
    }
}
