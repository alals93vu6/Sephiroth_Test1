using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private float DelayTime;
    
    public void OnEnterState(object action)
    {
        //Debug.Log("IsJump");
        
        DelayTime = 0f;
        PlayerAnimatorManager.instance.PlayJump();
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor.PlayerMove();
        actor.PlayerAttacking();
        //actor.PlayerDownWhether();

        //Debug.Log(DelayTime);

        DelayTime += Time.deltaTime;

        if (DelayTime >= 0.4f)
        {
            //Debug.Log("準備著陸");
            actor.ChangeState(new DropState());
        }


    }

    public void OnExitState(object action)
    {
        
    }
}
