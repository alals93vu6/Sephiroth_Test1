using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonState : IState
{
    public void OnEnterState(object action)
    {
        var actor = (ShiActor) action;
        
        actor._weaponData.LogState = 2;
        actor.SummonON = true;
        Debug.Log("IsSummons");
    }

    public void OnStayState(object action)
    {
        var actor = (ShiActor) action;
        actor.SummonsPosMaxDetection();
        
        if (actor.transform.position.x <= actor._weaponData.PlayerX)
        {
            actor.TurnLeft();
        }
        else
        {
            actor.TurnRight();
        }
        /*
        if (actor.GetNowShiGapPosX() >= 12 || actor.GetNowShiGapPosY() >= 8)
        {
            actor.ShiReTurn();
        }

        if (Input.GetAxis("CallWeapon") >= 0.85f || Input.GetMouseButtonDown(1) && actor.SummonCD == false)
        {
            actor.ShiReTurn();
            actor.OnSummonCD();
        }
        */
        if (Input.GetButtonUp("CallWeapon") && actor.SummonCD == false)
        {
            actor.ShiReTurn();
            actor.OnSummonCD();
        }
        
        //actor.ShiAttack();

        
    }

    public void OnExitState(object action)
    {
        var actor = (ShiActor) action;
    }
}
