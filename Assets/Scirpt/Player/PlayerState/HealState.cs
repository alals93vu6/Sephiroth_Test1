using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealState : IState
{
    private float healTime;
    
    public void OnEnterState(object action)
    {
        var actor = (PlayerActor) action;
        actor.rig.velocity = Vector2.zero;
        healTime = 0f;
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor._animatorManager.playHeal(actor.PassState);
        healTime += Time.deltaTime;

        if (Input.GetButtonUp("YKey") || healTime >= 1.11f)
        {
            actor.changeState(new IdleState());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        if (healTime >= 1.1f)
        {
            actor._playerFettle.NowHP++;
        }
    }
}
