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
        AttackTime = 0f;

        if (actor.IsConnect)
        {
            //Debug.Log("WeaponAttack");
            //actor._weaponAnimator.OnWeaponAttack();
        }
        else
        {
            actor._animatorManager.PlayAttack();
        }
        EventBus.Post(new PlayerAttackDetected());
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        AttackTime += Time.deltaTime;
        actor.PlayerMove();
        actor.HitDetected();

        if (AttackTime >= 0.5f)
        {
            if (!Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor))
            {
                actor.changeState(new DropState());
            }
            else
            {
                if (Input.GetAxis("Horizontal") != 0)
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
