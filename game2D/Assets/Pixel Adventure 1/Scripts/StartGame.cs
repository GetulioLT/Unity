using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StGame()
    {
        Debug.Log("Inicio");
        SceneManager.LoadScene("Fase1");
    }
    public void EndGame()
    {
        Debug.Log("Final");
        Application.Quit();
    }
}
