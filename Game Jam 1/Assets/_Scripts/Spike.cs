using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private PolygonCollider2D polyCol;
        private SpriteRenderer Srend;
    // Start is called before the first frame update
    void Start()
    {
        polyCol= GetComponent<PolygonCollider2D>();
        Srend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Srend.enabled = false;
    }
}
