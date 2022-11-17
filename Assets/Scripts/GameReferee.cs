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
    LOSE,
    MAIN_MENU

}


public class GameReferee : MonoBehaviour
{
    public ActualGameState _defGameState;
    public float _fltGameCronometer;
    public float _fltGameTime = 10.0f;
    public BallMechanics _ballMechanics;
    public TextMeshProUGUI _tmpTimeRemaining;
    public TextMeshProUGUI _tmpCoinScore;
    public TextMeshProUGUI _tmpHealthPoints;
    public TextMeshProUGUI _tmpBullets;
   // public GameObject _goLoseScreen;
    public GameObject _goHUD;
   // public GameObject _goVictoryScreen;
    public GameObject _goPauseScreen;
    public GameObject _goShotUI;
    public bool isCanvasActive = true;
    

    //public void HandleCoreMechanic(CoreMechanics value, bool CursorLocked = true)
    //{
    //    switch (value)
    //    {
    //        case CoreMechanics.PAUSE:
    //            PauseGame(CursorLocked);
               
    //            break;
    //        case CoreMechanics.RESTART:
    //            RestartGame();
    //            break;

    //    }
    //}


    //public void HandleCoreMechanic(CoreMechanics value, Vector2 action)
    //{
    //    if (_defGameState == ActualGameState.GAME)
    //    {
    //        _scrAvatarMechanic.HandleCoreMechanic(value, action);
    //    }
    //}

    public void PauseGame(bool CursorLocked = true)
    {
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                _defGameState = ActualGameState.PAUSE;

                Time.timeScale = 0.0f;

                _goHUD.SetActive(false);
                _goPauseScreen.SetActive(true);
               
                break;
            case ActualGameState.PAUSE:
                _defGameState = ActualGameState.GAME;
                _goHUD.SetActive(true);
                _goPauseScreen.SetActive(false);
                Time.timeScale = 1.0f;

                break;

        }
        
    }


    protected void RestartGame(bool CursorLocked = true)
    {
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                _goShotUI.SetActive(true);
                break;
            case ActualGameState.PAUSE:
            case ActualGameState.VICTORY:
            case ActualGameState.LOSE:
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(1);

                break;

            case ActualGameState.MAIN_MENU:

                break;
        }
    }

    private void Start()
    {
        _fltGameCronometer = _fltGameTime;
    }


    private void Update()
    {
        if (_fltGameCronometer <= 120 && isCanvasActive)
        {
            //_goVictoryCanvas.SetActive(false);
            isCanvasActive = !isCanvasActive;
        }
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                Time.timeScale = 1.0f;
                _goShotUI.SetActive(true);
                _fltGameCronometer -= Time.deltaTime;

                _fltGameCronometer = Mathf.Clamp(_fltGameCronometer, 0.0f, Mathf.Infinity);

                //_tmpHealthPoints.text = ": " + _ballMechanics._intHealthPoints.ToString("0");

                _tmpTimeRemaining.text = ": " + _fltGameCronometer.ToString("00");

        
                


                if (_ballMechanics._intHealthPoints <= 0)
                {
                    _defGameState = ActualGameState.LOSE;
                    _goHUD.SetActive(false);
                    //_goLoseScreen.SetActive(true);
                    Time.timeScale = 0f;

                }

                if (_fltGameCronometer <= 0.0f)
                {
                    _defGameState = ActualGameState.LOSE;
                    _goHUD.SetActive(false);
                    //_goLoseScreen.SetActive(true);
                    Time.timeScale = 0f;


                  
                }

                break;

        }


    }
    public void VictoryGoalMechanicAchieved()
    {
        switch (_defGameState)
        {
            case ActualGameState.GAME:
                if (_fltGameCronometer > 0.0f)
                {
                    _defGameState = ActualGameState.VICTORY;
                    _goHUD.SetActive(false);
                    //_goVictoryScreen.SetActive(true);
                    Time.timeScale = 0f;

                }

                break;
        }
    }
    public void ActivateCanvas()
    {
        //_goVictoryCanvas.SetActive(true);
        //_goVictoryScreen.SetActive(false);


       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("1");
    }
    
}