using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer toRender;

    public void Init(bool isOffset)
    {
        toRender.color = isOffset ? offsetColor : baseColor;
    }

    
}