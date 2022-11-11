using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IState
{
    public void OnEnterState(object action)
    {
        Debug.Log("Dash");
        var actor = (PlayerActor) action;
        actor._animatorManager.playDash();
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
}
