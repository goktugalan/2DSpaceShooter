using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCountDownerUI : MonoBehaviour
{
    public TextMeshProUGUI enemy1CountdownText;
    public TextMeshProUGUI enemy2CountdownText;

    private int enemy1KillCountdown = 0;
    private int enemy2KillCountdown = 0;

    public void IncrementKillCount(string enemyTag)
    {
        if (enemyTag == "Enemy 1")
        {
            enemy1KillCountdown++;
            enemy1CountdownText.text = ": " + enemy1KillCountdown;
        }
        else if (enemyTag == "Enemy")
        {
            enemy2KillCountdown++;
            enemy2CountdownText.text = ": " + enemy2KillCountdown;
        }
    }
}

