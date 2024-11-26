using UnityEngine;
using UnityEngine.UI;

public class AttackSpeedBarController : MonoBehaviour
{
    private PlayerController playerController;
    public Image attackSpeedBar;
    public Canvas boostTrackCanvas;
    private float totalTime = 2.5f;
    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
        attackSpeedBar.fillAmount = 1f; // Start with the bar fully filled
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerController.attackSpeedBoost == true)
        {
            currentTime -= Time.deltaTime;

            // Update the fill amount based on the remaining time
            attackSpeedBar.fillAmount = currentTime / totalTime;

            // Disable the bar when time runs out
            if (currentTime <= 0)
            {
                boostTrackCanvas.gameObject.SetActive(false);
                currentTime = 2.5f;
            }
        }
    }
}
