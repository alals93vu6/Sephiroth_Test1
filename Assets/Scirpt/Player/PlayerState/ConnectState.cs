using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectState : IState
{
    public void OnEnterState(object action)
    {
        //Debug.Log("IsConnect");
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor.ConnectDetected();
        //actor.PlayerMove();
    }

    public void OnExitState(object action)
    {
        //Debug.Log("NotConnect");
    }
}
