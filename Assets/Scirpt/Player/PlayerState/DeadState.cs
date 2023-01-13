using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    public void OnEnterState(object action)
    {
        //Debug.Log("PlayerDead");
        var actor = (PlayerActor) action;
        actor.rig.velocity = Vector2.zero;
        actor._animatorManager.playDead(actor.PassState);
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
}
