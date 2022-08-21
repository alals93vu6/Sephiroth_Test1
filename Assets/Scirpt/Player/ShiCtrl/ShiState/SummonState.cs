using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonState : IState
{
    public void OnEnterState(object action)
    {
        Debug.Log("IsSummons");
    }

    public void OnStayState(object action)
    {
        var actor = (ShiActor) action;
        actor.SummonsPosMaxDetection();
        
        if (actor.GetNowShiGapPosX() >= 12 || actor.GetNowShiGapPosY() >= 8)
        {
            actor.ShiReTurn();
            actor.ChangeState(new FollowState());
        }
        
    }

    public void OnExitState(object action)
    {
        
    }
}
