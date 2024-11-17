using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteListener : MonoBehaviour
{
    [SerializeField] SpriteAtlas atlas;
    [SerializeField] string spriteName;

    void Start()
    {
        GetComponent<Image>().sprite = atlas.GetSprite(spriteName);
    }
}
