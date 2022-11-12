﻿using System.Collections;
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
        actor._animatorManager.playDrop();

        if (Physics2D.OverlapCircle(actor.transform.position - actor.JumpAera, actor.jumpRange, actor.jumpfloor))
        {
            actor.onTheMoveDetected();
        }

    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
}
