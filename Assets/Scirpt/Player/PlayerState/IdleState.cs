using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void OnEnterState(object action)
    {
        Debug.Log("IsIdle");
        var actor = (PlayerActor) action;
        //
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        if (Mathf.Abs(actor.H) >= 0.4f)
        {
            actor.changeState(new MoveState());
        }

        if (Input.GetButtonDown("AKey"))
        {
            actor.changeState(new JumpState());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        
        //actor.rig.velocity = new Vector2(0, actor.rig.velocity.y);
    }
    
}
