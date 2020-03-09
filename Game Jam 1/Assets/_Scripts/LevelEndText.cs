using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndText : MonoBehaviour
{
    [SerializeField] private string text1 = "Eeek....";
    [SerializeField] private string text2 = "thats a lot of deaths";
    [SerializeField] private string text3 = "you can do better";
    [SerializeField] private string text4 = "You aren't supposed to get THAT many deaths";
    [SerializeField] private string text5 = "you should try again";

    public static int scoreValue = 0;
    [SerializeField] private Text numDeaths;
    // Start is called before the first frame update
    void Start()
    {
        numDeaths = GetComponent<Text>();
        Debug.Log(numDeaths);
    }


    // Update is called once per frame
    void Update()
    {
        if(scoreValue < 10)
        {
            numDeaths.text = "Deaths: " + scoreValue + "\n" + text1;
        }
        else if (scoreValue < 15)
        {
            numDeaths.text = "Deaths: " + scoreValue + "\n" + text2;
        }
        else if (scoreValue < 20)
        {
            numDeaths.text = "Deaths: " + scoreValue + "\n" + text3;
        }
        else if (scoreValue < 25)
        {
            numDeaths.text = "Deaths: " + scoreValue + "\n" + text4;
        }
        else
        {
            numDeaths.text = "Deaths: " + scoreValue + "\n" + text5;
        }
    }

}
