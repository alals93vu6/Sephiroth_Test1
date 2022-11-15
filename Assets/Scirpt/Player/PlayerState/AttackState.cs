using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class AttackState : IState
{
    private float AttackTime;
    public void OnEnterState(object action)
    {
        var actor = (PlayerActor) action;
        actor._animatorManager.PlayAttack();
        
        AttackTime = 0f;
        EventBus.Post(new PlayerAttackDetected());
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        AttackTime += Time.deltaTime;
        actor.PlayerMove();

        if (AttackTime >= 0.5f)
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
        //actor.StopSlip();
    }
}
