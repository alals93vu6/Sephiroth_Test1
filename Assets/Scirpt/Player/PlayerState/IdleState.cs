using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void OnEnterState(object action)
    {
        //Debug.Log("IsIdle");
        var actor = (PlayerActor) action;
        
        //
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor._animatorManager.playIdle();
        if (Mathf.Abs(actor.H) >= 0.4f)
        {
            actor.changeState(new MoveState());
        }
        if (Physics2D.OverlapCircle(actor.transform.position - actor.JumpAera, actor.jumpRange, actor.jumpfloor) 
            && Input.GetButtonDown("AKey"))
        {
            actor.changeState(new JumpState());
        }
        if (!Physics2D.OverlapCircle(actor.transform.position - actor.JumpAera, actor.jumpRange, actor.jumpfloor))
        {
            actor.changeState(new DropState());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        
        //actor.rig.velocity = new Vector2(0, actor.rig.velocity.y);
    }
    
}
