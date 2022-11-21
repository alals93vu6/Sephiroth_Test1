using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class HitState : IState
{
    private float HitTime;
    public void OnEnterState(object action)
    {
        HitTime = 0f;
        Debug.Log("OnHit");
        var actor = (PlayerActor) action;
        actor.GetDamage();
        if (actor._animatorManager._spriteRenderer.flipX)//4
        {
            actor.rig.AddForce(new Vector2(-3,0) , ForceMode2D.Impulse);
        }
        else
        {
            actor.rig.AddForce(new Vector2(3,0) , ForceMode2D.Impulse);
        }
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        HitTime += Time.deltaTime;
        /*
        if (HitTime >= 0.3f)
        {
            actor.rig.velocity = Vector2.zero;
        }
        */
        if (HitTime >= 0.8f)
        {
            if (!Physics2D.OverlapCircle(actor.transform.position - actor.JumpAera, actor.jumpRange, actor.jumpfloor))
            {
                actor.changeState(new DropState());
            }
            else
            {
                if (actor.H != 0)
                {
                    actor.changeState(new MoveState());
                }
                else
                {
                    actor.rig.velocity = Vector2.zero;
                    actor.changeState(new IdleState());
                }
            }
        }
    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
}
