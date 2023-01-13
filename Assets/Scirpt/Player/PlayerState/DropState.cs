using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropState : IState
{
    public void OnEnterState(object action)
    {
        //Debug.Log("IsDrop");
        var actor = (PlayerActor) action;
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor.PlayerMove();
        actor.HitDetected();
        actor._animatorManager.playDrop(actor.PassState);

        if (Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor))
        {
            actor.onTheMoveDetected();
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
