using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IState
{
    private float DashTime;
    public void OnEnterState(object action)
    {
        //Debug.Log("Dash");
        var actor = (PlayerActor) action;
        actor._animatorManager.playDash();
        DashTime = 0f;
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;

        DashTime += Time.deltaTime;

        if (DashTime >= 0.5f)
        {
           if (!Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor))
           {
               actor.changeState(new DropState());
           }
           else
           {
               actor.onTheMoveDetected();
            } 
        }

        
        
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
}
