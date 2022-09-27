using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    public GameObject gameOver;
    public string scena;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            Pause.isPlayer = false;
        }
    }

    public void Resume()
    {
        SceneManager.LoadScene(scena);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
