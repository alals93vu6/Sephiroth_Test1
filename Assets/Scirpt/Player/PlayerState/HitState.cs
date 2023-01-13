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
        //Debug.Log("OnHit");
        var actor = (PlayerActor) action;
        actor.GetDamage();
        actor.rig.velocity = Vector2.zero;
        actor._animatorManager.playHit(actor.PassState);
        if (Physics2D.OverlapBox( actor.transform.position - actor._playerData.HitDetected,
            actor._playerData.hitDetectedbox, 0, actor.HitObj))
        {
            actor._playerData.HitandDashOffset = new Vector3(actor.transform.position.x - 3,0,0);
            //actor.rig.AddForce(new Vector2(-5,0) , ForceMode2D.Impulse);
        }
        else
        {
            actor._playerData.HitandDashOffset = new Vector3(actor.transform.position.x + 3,0,0);
            //actor.rig.AddForce(new Vector2(5,0) , ForceMode2D.Impulse);
        }
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        HitTime += Time.deltaTime;
        actor.transform.position = new Vector3(Mathf.Lerp(actor.transform.position.x, actor._playerData.HitandDashOffset.x, 0.03f)
            , actor.transform.position.y,actor.transform.position.z);
        //actor.transform.position = Mathf.Lerp(actor.transform.position, actor._playerData.hitStepBack, 0.01f);
        /*
        if (HitTime >= 0.3f)
        {
            actor.rig.velocity = Vector2.zero;
        }
        */
        if (HitTime >= 0.8f)
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
    }
}
