using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    Scene myScene;
    public int sceneIndex;
    


    void Start()
    {
        int index = myScene.buildIndex;
        sceneIndex = index;
       
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

    public void Restart(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void NxtLevel(int sceneName)
    { 
        SceneManager.LoadScene(sceneName);

    }

    
}

