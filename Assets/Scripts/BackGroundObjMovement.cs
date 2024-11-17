using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundObjMovement : MonoBehaviour
{
    public float backgroundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(backgroundSpeed, 0, 0 * Time.deltaTime);
        if(transform.position.x <= -32.25f)
        {
            transform.position = new Vector2(32.25f, 0);
        }
    }
}
