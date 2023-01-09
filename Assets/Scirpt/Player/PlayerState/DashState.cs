using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IState
{
    private float DashTime;
    
    public void OnEnterState(object action)
    {
        //Debug.Log("Dash");
        var actor = (PlayerActor) action;
        if (actor.PassState == 1)
        {
            actor._playerData.HitandDashOffset.y = actor.transform.position.x + 5f;
        }
        else
        {
            actor._playerData.HitandDashOffset.y = actor.transform.position.x - 5f;
        }
        actor.rig.velocity = Vector2.zero;
        actor._animatorManager.playDash();
        DashTime = 0f;
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;

        DashTime += Time.deltaTime;
        actor.transform.position = new Vector3(Mathf.Lerp(actor.transform.position.x, actor._playerData.HitandDashOffset.y, 0.035f)
            ,actor.transform.position.y,actor.transform.position.z);

        if (DashTime >= 0.5f)
        {
           if (!Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor))
           {
               actor.changeState(new DropState());
           }
           else
           {
               actor.onTheMoveDetected();
            } 
        }

        
        
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
}
