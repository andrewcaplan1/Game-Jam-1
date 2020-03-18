using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //LoadNextLevel();

            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        }
        
    }
}
