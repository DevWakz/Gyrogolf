using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CoreMechanics
{
    PAUSE,
    RESTART,
    MOVEMENT
}
public class CoreMechanicsHandler : MonoBehaviour
{
    public GameReferee _scrGameReferee;

    public Vector2 _v2Movement;
    public bool _isPaused;
    public bool _isRestart;
    public float deadTime = 0;
    

    //public void HandleMovement(InputAction.CallbackContext context)
    //{
    //    _v2Movement = context.ReadValue<Vector2>();
    //    Debug.Log("CoreMechanicsHandler - HandeleMOvement");
    //    _scrGameReferee.HandleCoreMechanic(CoreMechanics.MOVEMENT, _v2Movement);
    //}



    //public void HandlePause(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        _isPaused = true;
    //    }
    //    if (context.canceled)
    //    {
    //        _isPaused = false;
    //    }
    //    _scrGameReferee.HandleCoreMechanic(CoreMechanics.PAUSE);

    //}

    //public void HandleRestart(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        _isRestart = true;
    //    }
    //    if (context.canceled)
    //    {
    //        _isRestart = false;
    //    }
    //    _scrGameReferee.HandleCoreMechanic(CoreMechanics.RESTART, _isRestart);
    //}

    private void Update()
    {
        if (deadTime != 0)
        {

        }
    }
}
