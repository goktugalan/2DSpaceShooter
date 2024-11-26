using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public int heart;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private PlayerObjectCollider playerObjectCollider;

    void Start()
    {
        playerObjectCollider = FindAnyObjectByType<PlayerObjectCollider>();
    }
    void Update()
    {
        if (playerObjectCollider.playerLife > numOfHearts)
        {
            playerObjectCollider.playerLife = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerObjectCollider.playerLife)
            {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
