using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileThatCanBreak : MonoBehaviour
{

    void Start()
    {
        Renderer rend = GetComponent<TilemapRenderer>();
        rend.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
