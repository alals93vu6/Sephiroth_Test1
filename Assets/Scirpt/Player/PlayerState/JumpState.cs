using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private float DelayTime;
    
    public void OnEnterState(object action)
    {
        var actor = (PlayerActor) action;
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
