using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject _goShotUI;
    void Start()
    {

    }
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }


    
}

