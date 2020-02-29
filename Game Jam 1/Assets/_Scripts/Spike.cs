using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private SpriteRenderer Srend;

    void Start()
    {
        Srend = GetComponent<SpriteRenderer>();
        Srend.enabled = false;
    }

}
