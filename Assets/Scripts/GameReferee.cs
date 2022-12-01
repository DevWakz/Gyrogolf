using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public enum ActualGameState
{
    GAME,
    PAUSE,
    VICTORY,
    DEFEAT,
    MAIN_MENU

}


public class GameReferee : MonoBehaviour
{
    public ActualGameState _defGameState;

    public BallMechanics _ballMechanics;
    public GameObject _goHUD;
    public GameObject _goPauseScreen;
    public GameObject _goShotUI;
    public GameObject _goVictoryScreen;
    public GameObject _goDefeatScreen;
    Gyroscope myGyro;

    void Start()
    {
        myGyro = Input.gyro;
    }

    public void PauseGame()
    {
       
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                _defGameState = ActualGameState.PAUSE;
                Time.timeScale = 0.0f;
                myGyro.enabled = false;
                _goHUD.SetActive(false);
                _goPauseScreen.SetActive(true);
               
                break;
            case ActualGameState.PAUSE:
                _defGameState = ActualGameState.GAME;
                Time.timeScale = 1.0f;
                myGyro.enabled = true;
                _goHUD.SetActive(true);
                _goPauseScreen.SetActive(false);
                

                break;

        }
        
    }


    protected void RestartGame()
    {
        switch (_defGameState)
        {
            case ActualGameState.GAME:
            case ActualGameState.PAUSE:
            case ActualGameState.VICTORY:
            case ActualGameState.DEFEAT:
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(1);

                break;

            case ActualGameState.MAIN_MENU:

                break;
        }
    }

 


    private void Update()
    { 
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                Time.timeScale = 1.0f;
                break;

            case ActualGameState.DEFEAT:
                Time.timeScale = 0.0f;
                break;
        }


    }
    public void Victory()
    {
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                    _defGameState = ActualGameState.VICTORY;
                    _goHUD.SetActive(false);
                    _goVictoryScreen.SetActive(true);
                    Time.timeScale = 0.0f;

                break;
        }
    }


    
}