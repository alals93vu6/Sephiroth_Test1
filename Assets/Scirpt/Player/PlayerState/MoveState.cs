using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{

    public void OnEnterState(object action)
    {
        Debug.Log("IsMove");
        var actor = (PlayerActor) action;
        
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor._animatorManager.playMove();
        actor.PlayerMove();
        
        if (Mathf.Abs(actor.H) <= 0.39f)
        {
            actor.rig.velocity = Vector2.zero;
            actor.changeState(new IdleState());
        }
        
        if (Physics2D.OverlapCircle(actor.transform.position - actor.JumpAera, actor.jumpRange, actor.jumpfloor) 
            && Input.GetButtonDown("AKey"))
        {
            actor.changeState(new JumpState());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        
    }
}
