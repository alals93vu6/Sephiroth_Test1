using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{

    public void OnEnterState(object action)
    {
        //Debug.Log("IsMove");
        var actor = (PlayerActor) action;
        
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor._animatorManager.playMove();
        actor.HitDetected();
        actor.PlayerMove();
        
        if (Input.GetButtonDown("BKey"))
        {
            actor.onPlayerDash(2.5f);
            actor.changeState(new DashState());
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.39f)
        {
            actor.rig.velocity = Vector2.zero;
            actor.changeState(new IdleState());
        }
        if (Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor) 
            && Input.GetButtonDown("AKey") && Input.GetAxis("Vertical") >= -0.5f)
        {
            actor.changeState(new JumpState());
        }
        if (!Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor))
        {
            actor.changeState(new DropState());
        }
        if (Input.GetButtonDown("XKey"))
        {
            actor.changeState(new AttackState());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        
    }
}
