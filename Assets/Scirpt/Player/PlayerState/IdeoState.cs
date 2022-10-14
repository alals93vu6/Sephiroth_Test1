﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeoState : IState
{
    public void OnEnterState(object action)
    {
        //Debug.Log("IsIdeo");
        PlayerAnimatorManager.instance.PlayIdeo();
        var actor = (PlayerActor) action;
        actor.DashFouce = 7f;
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        //actor.PlayerMove();
        actor.OnPlayerMoveDetect();
        actor.OnPlayerJump();
        actor.PlayerJumpWhether();
        actor.OnPlayerSquatDetect();
        actor.OnPlayerDash();
        actor.PlayerAttacking();

        if (actor.IsMove)
        {
            actor.ChangeState(new MoveState());
        }

        //Debug.Log("IsIdeo");
    }

    public void OnExitState(object action)
    {
        PlayerAnimatorManager.instance.ExitIdeo();
    }
}
