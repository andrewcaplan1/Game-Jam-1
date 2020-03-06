using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spike : MonoBehaviour
{
    private SpriteRenderer SRenderer;
    private TilemapRenderer TRenderer;

    void Start()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        TRenderer = GetComponent<TilemapRenderer>();
        SRenderer.enabled = false;
        TRenderer.enabled = false;

    }

}
