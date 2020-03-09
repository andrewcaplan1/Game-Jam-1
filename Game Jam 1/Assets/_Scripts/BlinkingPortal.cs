using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class BlinkingPortal : MonoBehaviour
{
    //[SerializeField] private Light2D light;
    [SerializeField] private SpriteRenderer col;
    public float time = 1;
    public float speed;

    void FixedUpdate()
    {
        
        col.color = new Color(col.color.r,col.color.g,col.color.b, Mathf.PingPong(Time.fixedTime * speed, time));
        //light.intensity = Mathf.PingPong(Time.time *speed, time);
    }

    
}
