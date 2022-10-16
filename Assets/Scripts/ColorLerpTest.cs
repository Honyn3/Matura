using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerpTest : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private Color previousColor;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        previousColor = SpriteRenderer.color;
    }

    private void Update()
    {
            SpriteRenderer.material.color = Color.Lerp(SpriteRenderer.material.color, Color.red, 0.01f);
    }
}
