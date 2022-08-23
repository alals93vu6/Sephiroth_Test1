using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    
    public void OnEnterState(object action)
    {
        //Debug.Log("IsMove");
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        
        actor.PlayerMove();
        actor.OnPlayerJump();
        actor.PlayerJumpWhether();

        if (Input.GetAxis("HorizontalA") == 0)
        {
            actor.ChangeState(new IdeoState());
        }
    }

    public void OnExitState(object action)
    {
        
    }
}
