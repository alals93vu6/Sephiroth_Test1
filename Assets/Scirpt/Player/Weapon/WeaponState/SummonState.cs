using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonState : IState
{
    public void OnEnterState(object action)
    {
        var actor = (ShiActor) action;
        actor.SummonPosition();
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

        if (Input.GetAxis("SummonKey") >= 0.85f || Input.GetMouseButtonDown(1) && actor.SummonCD == false)
        {
            actor.ShiReTurn();
            actor.ChangeState(new FollowState());
            actor.OnSummonCD();
        }
        
        //actor.ShiAttack();

        
    }

    public void OnExitState(object action)
    {
        
    }
}
