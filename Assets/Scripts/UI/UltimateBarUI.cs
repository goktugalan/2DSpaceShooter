using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimateBarUI : MonoBehaviour
{
    [SerializeField] private Image ultimateBar; // Reference to the UI image
    [SerializeField] private float maxUltimate = 100f; // Max ultimate points
    public TextMeshProUGUI ultReadyText;
    [HideInInspector] public float currentUltimate = 0f; // Current ultimate points


    public void AddUltimatePoints(float points)
    {
        currentUltimate += points;
        currentUltimate = Mathf.Clamp(currentUltimate, 0, maxUltimate); // Ensure it doesn't exceed the max
        UpdateUltimateBar();

        ultReadyText.gameObject.SetActive(currentUltimate == 100f);
    }

    public void UpdateUltimateBar()
    {
        if (ultimateBar != null)
        {
            ultimateBar.fillAmount = currentUltimate / maxUltimate;
        }
    }
}
