using UnityEngine;
using System.Collections;
using Cinemachine;
//UnityEngine.Experimental.Rendering.Universal
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;
using System;



public class MasterLighting: MonoBehaviour
{
    private Light2D[] lights;
    private float[] lightsReference;
    public float intense = 1;
    private float num;
    [SerializeField] private ParticleSystem fog;
    //LevelSelector nextLevel;

    void Awake()
    {
        lights = (Light2D[])GameObject.FindObjectsOfType(typeof(Light2D));
        num = lights.Length;
        Array.Resize(ref lightsReference, lights.Length);
        for (int i = 0; i < lights.Length; i++)
        {
            lightsReference[i] = lights[i].intensity;
            
        }

    }

    void FixedUpdate()
    {
        
        if (num != intense)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].intensity = lightsReference[i] * intense;
                Debug.Log("work?");
            }
        }
        num = intense;

        if (intense <= 0)
        {
            fog.Stop();
        }
        else
        {
            fog.Play();
        }
    }

}
