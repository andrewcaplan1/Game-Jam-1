using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] Levels;
    [SerializeField] private string nextLevel;
    [SerializeField] private GameObject PlayUI;
    [SerializeField] private GameObject LevelSelectUI;
    [SerializeField] [Range(0,1)] private float lightSmoothingFactor;


    public void PrepareNextLevel(string nextLevelName)
    {
        nextLevel = nextLevelName;
    }

    public void DoLoad()
    { 
        LoadNextLevel(nextLevel);
    }

    public void LoadNextLevel(string nextLevelName)
    {
        Debug.LogError("you did it:" + nextLevelName);
        while(MasterLighting.m_intense > 0)
        {
            MasterLighting.m_intense -= Time.smoothDeltaTime * lightSmoothingFactor;
        }
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
}