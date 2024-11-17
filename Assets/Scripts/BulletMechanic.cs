using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanic : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    [SerializeField] int bulletSpeed;
    private int maxBulletPos = 25;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        BulletMove();
        BulletBorders();
    }
    void BulletMove()
    {
        bulletRb.velocity = Vector2.right * bulletSpeed;
    }
    private void BulletBorders()
    {
        if(transform.position.x > maxBulletPos && transform.position.x < -maxBulletPos)
        {
            Destroy(gameObject);
        }
    }
}
