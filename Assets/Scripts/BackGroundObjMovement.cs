using UnityEngine;

public class BackGroundObjMovement : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;

    void Update()
    {
        transform.Translate(backgroundSpeed, 0, 0 * Time.deltaTime);
        if(transform.position.x <= -32.25f)
        {
            transform.position = new Vector2(32.25f, 0);
        }
    }
}
