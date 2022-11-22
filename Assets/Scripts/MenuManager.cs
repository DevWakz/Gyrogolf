using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject _goShotUI;
    [SerializeField]
    

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

    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void NxtLevel(string sceneName)
    { 
        SceneManager.LoadScene(sceneName);

    }

    
}

