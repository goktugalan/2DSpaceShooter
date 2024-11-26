using UnityEngine;

public class ObjectSlider : MonoBehaviour
{
    private Rigidbody2D objectRb;
    [SerializeField] int objectSpeed;
    private int maxObjectPos = 25;
    void Start()
    {
        objectRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ObjectMove();
        ObjectBorders();
    }
    void ObjectMove()
    {
        objectRb.velocity = Vector2.right * objectSpeed;
    }
    private void ObjectBorders()
    {
        if(transform.position.x > maxObjectPos || transform.position.x < -maxObjectPos)
        {
            Destroy(gameObject);
        }
    }
}
