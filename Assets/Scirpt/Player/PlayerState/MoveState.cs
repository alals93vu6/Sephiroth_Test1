using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    private float RunT;
    
    public void OnEnterState(object action)
    {
        //Debug.Log("IsMove");
        RunT = 0f;
        PlayerAnimatorManager.instance.PlayRun();
    }

    public void OnStayState(object action)
    {
        RunTime();
        
        var actor = (PlayerActor) action;
        
        actor.PlayerMove();
        actor.OnPlayerMoveDetect();
        actor.OnPlayerJump();
        actor.PlayerJumpWhether();
        actor.OnPlayerSquatDetect();

        //Debug.Log("IsMove");

        if (!actor.IsMove)
        {
            actor.ChangeState(new IdeoState());
            //Debug.Log("StopMove");
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        
        if (RunT >= 0.75f)
        {
            
            PlayerAnimatorManager.instance.PlayStopMove();
            actor.OnPlayerStopMove();
        }
        
    }

    private void RunTime()
    {
        RunT += Time.deltaTime;
        //Debug.Log(RunT);
    }
}
