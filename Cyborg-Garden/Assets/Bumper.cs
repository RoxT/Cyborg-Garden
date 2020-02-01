﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float forceMagnitude;

    private void OnCollisionEnter2D(Collision2D collision) {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 collisionNormal = collision.GetContact(0).normal;
        collisionNormal.Normalize();
        collisionNormal *= -forceMagnitude;
        rb.AddForce(collisionNormal, ForceMode2D.Impulse);
    }
}
