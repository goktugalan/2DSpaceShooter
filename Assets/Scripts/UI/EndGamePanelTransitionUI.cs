using UnityEngine;
using System.Collections;

public class EndGamePanelTransitionUI : MonoBehaviour
{
    public Vector3 translationAmount = new Vector3(0, 950, 0); // Total translation distance
    public float duration = 1.0f; // Duration of the transition in seconds

    private Vector3 initialPosition; // Store the initial position

    void OnEnable()
    {
        // Store the starting position
        initialPosition = transform.localPosition;

        // Start the smooth translation
        StartCoroutine(SmoothTranslate());
    }

    private IEnumerator SmoothTranslate()
    {
        float elapsedTime = 0f; // Track elapsed time
        Vector3 targetPosition = initialPosition + translationAmount;

        while (elapsedTime < duration)
        {
            // Interpolate position over time
            transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is reached
        transform.localPosition = targetPosition;
    }
}
