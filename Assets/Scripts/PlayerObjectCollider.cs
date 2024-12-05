using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectCollider : MonoBehaviour
{
    public int playerLife = 3;
    [SerializeField] private GameObject getHitVFX;
    [SerializeField] private GameObject gameOnPanels, gameOffPanels;
    private AudioSource playerAudioSource;
    [SerializeField] private AudioClip getHitSFX;

    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    private void SwitchPanels()
    {
        gameOnPanels.SetActive(false);
        gameOffPanels.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy Bullet") || other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
        {
            playerLife -= 1;
            Instantiate(getHitVFX, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            playerAudioSource.PlayOneShot(getHitSFX);
            // VFX SFX ekle
            if(playerLife <= 0)
            {
                // vfx
                SwitchPanels();
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
