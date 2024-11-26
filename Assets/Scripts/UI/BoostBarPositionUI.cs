using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBarPositionUI : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1);
    }
}
