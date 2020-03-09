using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearShooter : MonoBehaviour
{
    public Vector2 startPos;
    public GameObject shooter;

    private SpriteRenderer spearRend;
    private SpriteRenderer shooterRend;
    private Rigidbody spearRB;

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;

    private bool hit;

    private Color color;


    void Start()
    {
        spearRend = GetComponent<SpriteRenderer>();
        spearRend.enabled = false;

        shooter = GameObject.Find("SpearShooter");

        color = spearRend.material.color;

        shooterRend = shooter.GetComponent<SpriteRenderer>();
        shooterRend.enabled = false;

        spearRB = GetComponent<Rigidbody>();
        spearRB.constraints = RigidbodyConstraints.FreezePositionY;

        Physics.IgnoreCollision(GetComponent<Collider>(), shooter.GetComponent<Collider>());
    }
    void Update()
    {
        spearRB.velocity = new Vector2(-2f, 0);
        if (spearRend == true && hit == true)
        {
            StartCoroutine("Fade");
            transform.position = startPos;
            color.a = 1;
            hit = false;
        }
    }

    IEnumerator Fade()
    {
        while (color.a > 0)
        {
            color.a -= 0.1f * Time.deltaTime;
            spearRend.material.color = color;
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            spearRB.velocity = new Vector2 (0, 0);
            hit = true;
        }
    }
}
