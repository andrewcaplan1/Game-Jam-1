using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCountText : MonoBehaviour
{
    public bool test;
    [SerializeField] private Text numDeaths;
    [SerializeField] private TextMeshProUGUI numdeaths1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numDeaths != null)
        {
            numDeaths.text = "Deaths: " + LevelEndText.scoreValue;
        } else if (numdeaths1 != null)
        {
            numdeaths1.text = "Deaths: " + LevelEndText.scoreValue;
        }
    }
}
