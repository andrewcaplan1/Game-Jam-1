using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCountText : MonoBehaviour
{
    public bool test;
    [SerializeField] private Text numDeaths;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numDeaths.text = "Deaths: " + LevelEndText.scoreValue;
    }
}
