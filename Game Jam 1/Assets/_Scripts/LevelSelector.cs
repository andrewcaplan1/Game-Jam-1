using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] Levels;
    [SerializeField] private GameObject PlayUI;
    [SerializeField] private GameObject LevelSelectUI;
    [SerializeField] private CinemachineVirtualCamera Vcam1;
    [SerializeField] private CinemachineVirtualCamera Vcam2;
    [SerializeField] [Range(0, 1)] private float lightSmoothingFactor;
    [SerializeField] private Text LevelSelectTEXT;
    [SerializeField] private Text text2;
    private LevelEndText levelEndText;
    private int lowPriority = 1;
    private int highPriority = 2;
    private float previousIntensity;
    private bool noNextLevel;
    [SerializeField] private PlayerMovement playerscript;

    private string nextLevel;

    public void PrepareNextLevel(string nextLevelName)
    {
        nextLevel = nextLevelName;
        Vcam1.Priority = lowPriority;
        Vcam2.Priority = highPriority;
        PlayUI.SetActive(false);
        LevelSelectUI.SetActive(true);
    }

    public void DoLoad()
    {
        LoadNextLevel(nextLevel);
    }

    public void LoadNextLevel(string nextLevelName)
    {
        Debug.LogError("you did it:" + nextLevelName);
        previousIntensity = MasterLighting.m_intense;
        while (MasterLighting.m_intense > 0f)
        {
            MasterLighting.m_intense -= Time.smoothDeltaTime * lightSmoothingFactor;
        }
        if (!Levels[Levels.Length - 1].name.Equals(nextLevelName))
        {
            noNextLevel = true;
        }
        if (!noNextLevel)
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i].name.Equals(nextLevelName))
                {
                    Levels[i].SetActive(true);
                    Debug.Log(Levels[i].name + "---IS EQUAL TO---" + nextLevelName);
                }
                else
                {
                    Levels[i].SetActive(false);
                    Debug.Log(Levels[i].name + "---is not equal to---" + nextLevelName);
                }
            }
        }
        else
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            noNextLevel = false;
        }

        if (MasterLighting.m_intense <= 0)
        {
            while (MasterLighting.m_intense <= previousIntensity)
            {
                MasterLighting.m_intense += Time.smoothDeltaTime * lightSmoothingFactor;
            }
            Vcam1.Priority = highPriority;
            Vcam2.Priority = lowPriority;
            PlayUI.SetActive(true);
            LevelSelectUI.SetActive(false);
            LevelSelectTEXT.text = "TOTAL DEATHS: " + LevelEndText.scoreValue;
        }
        playerscript.Die();
        LevelEndText.scoreValue -= 1;
    }
}