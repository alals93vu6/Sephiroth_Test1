using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatState : IState
{
    public void OnEnterState(object action)
    {
        var actor = (PlayerActor) action;
        
        actor.OnSquatReady();
        PlayerAnimatorManager.instance.PlayIdeo();
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor.OnPlayerSquatDetect();
        
        LandFloor.instance.OnPlayerFloorCross();

        if(!actor.IsSquat)
        {
            actor.ChangeState(new IdeoState());
        }

        Debug.Log("IsSquat");
    }

    public void OnExitState(object action)
    {
        
    }
}
