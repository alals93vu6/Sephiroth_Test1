using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatState : IState
{
    public void OnEnterState(object action)
    {
        //Debug.Log("IsSquat");
        var actor = (PlayerActor) action;
        
        actor.OnSquatReady();
        PlayerAnimatorManager.instance.AN.Play("PlayerIdeoTest");
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor.OnPlayerSquatDetect();
        actor.OnPlayerDropFloor();
        actor.PlayerAttacking();
        //LandFloor.instance.OnPlayerFloorCross();

        if(!actor.IsSquat && !actor.IsJump)
        {
            actor.ChangeState(new IdeoState());
        }

        
    }

    public void OnExitState(object action)
    {
         
    }
}
