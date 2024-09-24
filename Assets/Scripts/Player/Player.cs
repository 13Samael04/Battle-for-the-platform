using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]


public class Player : MonoBehaviour
{
    public int LifeCount { get; private set; } = 3;

    public void AddLife()
    {
        LifeCount++;
    }

    public void TakeDamage(int damage)
    {
        LifeCount -= damage;
        Debug.Log(LifeCount);
    }
}
