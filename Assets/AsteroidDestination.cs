using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestination : MonoBehaviour
{
    private List<Vector2> destinations = new List<Vector2>
    {
        new Vector2(-19, 6),
        new Vector2(-19, 0),
        new Vector2(-19, -6)
    };
    private Vector2 chosenDestination;
    [SerializeField] private float speed = 9f;
    void Start()
    {
        int randomIndex = Random.Range(0, destinations.Count);
        chosenDestination = destinations[randomIndex];
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, chosenDestination, speed * Time.deltaTime);

        if ((Vector2)transform.position == chosenDestination)
        {
            Destroy(gameObject);
        }
    }

}
