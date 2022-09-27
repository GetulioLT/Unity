using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public static bool isPlayer;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            isPlayer = false;
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        isPlayer = true;
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
