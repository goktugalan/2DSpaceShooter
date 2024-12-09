using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 150f;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
