using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Debug.Log("trrgr");
        }
    }
}
