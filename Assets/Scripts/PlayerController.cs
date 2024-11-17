using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f, fireRate;
    private Animator anim;
    public GameObject bullets, flash;
    private float verticalInput;
    private Rigidbody2D playerRb;
    private int playerLife = 3;
    private bool canShoot = true;
    public bool attackSpeedBoost;
    private AudioSource playerAudioSource;
    [SerializeField] AudioClip shootAudio;
    public Canvas boostTrackCanvas;

    void Start()
    {
        NeededComponents();
    }

    void NeededComponents()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerShoot();
        PlayerBorders();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        playerRb.velocity = Vector2.up * verticalInput * moveSpeed;
        anim.SetFloat("Speed", playerRb.velocity.y);
    }

    private void PlayerShoot()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(verticalInput == 0 && canShoot == true)
            {
                StartCoroutine(canShootCoroutine());
                Vector3 bulletPosition = transform.position;
                bulletPosition.x += 1.25f;
                Instantiate(bullets, bulletPosition, bullets.transform.rotation);
                playerAudioSource.PlayOneShot(shootAudio);
                anim.SetTrigger("LetsTry");
                StartCoroutine(flashActivator());
            }
        }
    }

    IEnumerator canShootCoroutine()
    {
        canShoot = false;
        float waitTime = attackSpeedBoost ? 0.25f : 0.6f;
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    IEnumerator ResetAttackSpeedBoost()
    {
        float asBoostTime = 2.5f;
        yield return new WaitForSeconds(asBoostTime);
        attackSpeedBoost = false;
    }

    IEnumerator flashActivator()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }
    void PlayerBorders()
    {
        if(transform.position.x < -14.75f)
        {
            transform.position = new Vector3(-14.75f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > -14.75f)
        {
            transform.position = new Vector3(-14.75f, transform.position.y, transform.position.z);
        }
        if(transform.position.y > 8)
        {
            transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        }
        if(transform.position.y < -8.5f)
        {
            transform.position = new Vector3(transform.position.x, -8.5f, transform.position.z);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy Bullet") || other.CompareTag("Enemy"))
        {
            playerLife -= 1;
            Destroy(other.gameObject);
            // VFX SFX ekle
            if(playerLife <= 0)
            {
                // vfx sfx
                Destroy(gameObject);
            }
        }
        else if(other.CompareTag("Attack Boost") && attackSpeedBoost == false)
        {
            //vfx sfx
            attackSpeedBoost = true;
            boostTrackCanvas.gameObject.SetActive(true);
            StartCoroutine(ResetAttackSpeedBoost());
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("HP"))
        {
            Destroy(other.gameObject);
            if(playerLife < 3)
            {
                // vfx sfx
                playerLife += 1;
            }
        }
    }
}

