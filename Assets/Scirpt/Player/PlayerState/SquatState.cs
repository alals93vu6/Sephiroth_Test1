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
        
        if(Input.GetAxis("VerticalA") >= -0.6f)
        {
            actor.ChangeState(new IdeoState());
        }
    }

    public void OnExitState(object action)
    {
        
    }
}
