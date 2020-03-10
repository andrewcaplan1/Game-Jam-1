using UnityEngine;
using System.Collections;
using Cinemachine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;
using System;



public class MasterLighting: MonoBehaviour
{
    private Light2D[] lights;
    private float[] lightsReference;
    public static float m_intense = 1f;
    private float num;
    private float num1;
    [SerializeField] private ParticleSystem fog;
    [SerializeField] [Range(0,1)] private float intensity;
    //LevelSelector nextLevel;

    public float Intense
    {
        get { return m_intense; }
        set { m_intense = value; }
    }

    void Awake()
    {
        lights = (Light2D[])GameObject.FindObjectsOfType(typeof(Light2D));
        Array.Resize(ref lightsReference, lights.Length);
        for (int i = 0; i < lights.Length; i++)
        {
            lightsReference[i] = lights[i].intensity;
            
        }

    }

    void FixedUpdate()
    {
        
        if (num != m_intense || num1 != intensity)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].intensity = lightsReference[i] * m_intense * intensity;
                Debug.Log("work?");
            }
        }
        num = m_intense;
        num1 = intensity;

        if (m_intense <= 0)
        {
            fog.Stop();
        }
        else
        {
            fog.Play();
        }
    }

}
