using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spike : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer SRenderer;
    //[SerializeField] private TilemapRenderer TRenderer;
    [SerializeField] private Renderer rend;
    [SerializeField] private bool tilemapIsEnabled = false;

    void Start()
    {
        //SRenderer = GetComponent<SpriteRenderer>();
        //TRenderer = GetComponent<TilemapRenderer>();
        //SRenderer.enabled = false;
        //TRenderer.enabled = tilemapIsEnabled;
        rend = GetComponent<Renderer>();
        rend.enabled = false;

    }

    void Update()
    {
        tilemapIsEnabled = rend.enabled;
        //tilemapIsEnabled = TRenderer.enabled;
    }

}
