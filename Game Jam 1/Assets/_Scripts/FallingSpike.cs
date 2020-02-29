using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private Transform objectTransform;
    private Vector3 startPos;
    private SpriteRenderer Srend;
    private Rigidbody2D rb2d;

    void Start()
    {
        objectTransform = GetComponent<Transform>();
        startPos = objectTransform.position;
        Srend = GetComponent<SpriteRenderer>();
        Srend.enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log(collision.name);
            Debug.LogError(collision.name);
            transform.position = startPos;
            rb2d.velocity = new Vector3(0f, 0f, 0f);

        }
    }
}
