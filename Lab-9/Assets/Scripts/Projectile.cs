using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    public float damage = 10f;
    ObjectPool bulletPool;

    private void Start()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null )
        {
            enemy.TakeDamage(damage);
            bulletPool.ReturnObject(this.gameObject);

        }
    }
}

