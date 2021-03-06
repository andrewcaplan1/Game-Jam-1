﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    public PlayerMovement Player;
    [SerializeField] private float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    [SerializeField] private float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    [SerializeField] private float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter

    [SerializeField] private float ShakeElapsedTime = 0.0f;

    // Cinemachine Shake
    [SerializeField] private CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    // Use this for initialization
    void Start()
    {
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        ShakeElapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.onDeath)
        {
            Player.onDeath = false;
            ShakeElapsedTime = 0.0f;
            ShakeElapsedTime = ShakeDuration;
        }

        // If the Cinemachine component is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeElapsedTime > 0.0f)
            {
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                // Update Shake Timer
                ShakeElapsedTime -= Time.deltaTime;
            }
            else if (ShakeElapsedTime <= 0.0f)
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0.0f;
            }
        }

    }
}