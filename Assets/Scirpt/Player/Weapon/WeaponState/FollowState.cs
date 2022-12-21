using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IState
{
    public void OnEnterState(object action)
    {
        var actor = (ShiActor) action;
        actor._weaponAnimator.PlayDisConnect();
        actor._weaponData.LogState = 1;
        Debug.Log("IsFollow");
        actor.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void OnStayState(object action)
    {
        var actor = (ShiActor) action;
        actor.ShiFollowMove();
        actor.ShiFollowPosMax();
        actor.ShiRotation();
        //Debug.Log("VARC");

        if (Input.GetButtonDown("CallWeapon") && !actor.SummonCD)
        {
            actor.SummonsShi();
        }

        /*
        if (Input.GetAxis("SummonKey") >= 0.85f || Input.GetMouseButtonDown(1) && actor.SummonCD == false)
        {
            actor.SummonsShi();
            actor.ChangeState(new SummonState());
            actor.OnSummonCD();
        }
        */
    }

    public void OnExitState(object action)
    {
        
    }
    
}
