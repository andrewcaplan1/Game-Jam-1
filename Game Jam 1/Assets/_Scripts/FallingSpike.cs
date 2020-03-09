using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingSpike : MonoBehaviour
{
    private Transform objectTransform;
    private Vector3 startPos;
    private Renderer rend;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        objectTransform = GetComponent<Transform>();
        startPos = objectTransform.position;

        rend = GetComponent<Renderer>();
        rend.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            transform.position = startPos;
            rb2d.velocity = new Vector3(0f, 0f, 0f);

        }
    }
}
