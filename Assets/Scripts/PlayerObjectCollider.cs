using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectCollider : MonoBehaviour
{
    private int playerLife = 3;
    [SerializeField] private GameObject getHitVFX;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy Bullet") || other.CompareTag("Enemy"))
        {
            playerLife -= 1;
            Destroy(other.gameObject);
            Instantiate(getHitVFX, transform.position, Quaternion.identity);
            // VFX SFX ekle
            if(playerLife <= 0)
            {
                // vfx 
                Destroy(gameObject);
            }
        }

        else if(other.CompareTag("HP"))
        {
            if(playerLife < 3)
            {
                // vfx sfx
                playerLife += 1;
                Destroy(other.gameObject);
            }
        }
    }
}
