using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public ObjectPool bulletPool;
    public float bulletSpeed = 10f;
    public float force = 2000f;


    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        if (rbBullet != null)
        {
            rbBullet.velocity = Vector2.zero;
            rbBullet.angularVelocity = 0f;
            rbBullet.velocity = transform.up * bulletSpeed;  // consistent direction
        }

        StartCoroutine(DeactiveBullet(bullet));
    }


    IEnumerator DeactiveBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        bulletPool.ReturnObject(bullet);
    }
}
