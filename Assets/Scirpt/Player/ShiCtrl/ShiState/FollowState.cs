using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IState
{
    public void OnEnterState(object action)
    {
        Debug.Log("IsFollow");
    }

    public void OnStayState(object action)
    {
        var actor = (ShiActor) action;
        actor.ShiFollowMove();
        actor.ShiFollowPosMax();
        actor.ShiRotation();
        
        if (Input.GetButtonDown("XKey") || Input.GetKeyDown(KeyCode.H))
        {
            actor.SummonsShi();
            actor.ChangeState(new SummonState());
        }
        
    }

    public void OnExitState(object action)
    {
        
    }
    
}
