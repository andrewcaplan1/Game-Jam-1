using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    //private PolygonCollider2D polyCol;
    private SpriteRenderer Srend;
    // Start is called before the first frame update
    void Start()
    {
        //polyCol= GetComponent<PolygonCollider2D>();
        Srend = GetComponent<SpriteRenderer>();
        Srend.enabled = false;
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
        
    //    Srend.enabled = false;
    //}
    //void OnTriggerEnter2d(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Srend.enabled = true;
    //        //Die(other.gameObject);
    //    }
    //}
}
