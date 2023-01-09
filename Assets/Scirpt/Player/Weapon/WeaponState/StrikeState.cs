using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class StrikeState : IState
{
    private float StrikeTime;
    private float Speed;
    
    public void OnEnterState(object action)
    {
        var actor = (ShiActor) action;
        actor._weaponAnimator.PlayConnect();
        StrikeTime = 0f;
        Debug.Log("Strike!");
        actor.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        if (actor._playerActor.IsRight == 1)
        {
            Speed = actor._weaponData.StrikeSpeed;
            actor.transform.localScale = new Vector2(-0.12f, 0.12f);
        }
        else if (actor._playerActor.IsRight == 2)
        {
            Speed = -actor._weaponData.StrikeSpeed;
            actor.transform.localScale = new Vector2(0.12f, 0.12f);
        }
        else
        {
            if (actor._playerActor.PassState == 1)
            {
                Speed = actor._weaponData.StrikeSpeed;
                actor.transform.localScale = new Vector2(-0.12f, 0.12f);
            }
            else
            {
                Speed = -actor._weaponData.StrikeSpeed;
                actor.transform.localScale = new Vector2(0.12f, 0.12f);
            }
        }
    }
    public void OnStayState(object action)
    {
        var actor = (ShiActor) action;
        StrikeTime += Time.deltaTime;
        actor.Shirig.velocity = new Vector2(Speed , actor.Shirig.velocity.y);
        
        if (Input.GetButtonDown("CallWeapon") && !actor.SummonCD)
        {
            actor.ChangeState(new FollowState());
        }

        if (Physics2D.OverlapCircle(actor.transform.position + actor._weaponData.StrikeOffset,
            actor._weaponData.StrileRange, actor.StrikeLayer)
        || Physics2D.OverlapCircle(actor.transform.position - actor._weaponData.StrikeOffset,
            actor._weaponData.StrileRange, actor.StrikeLayer))
        {
            EventBus.Post(new PlayerAttackDetected());
            actor._weaponAnimator.OnWeaponAttack();
            actor.ChangeState(new SummonState());
        }
        
        if (Physics2D.OverlapCircle(actor.transform.position + actor._weaponData.StrikeOffset,
                actor._weaponData.StrileRange, 1024)
            || Physics2D.OverlapCircle(actor.transform.position - actor._weaponData.StrikeOffset,
                actor._weaponData.StrileRange, 1024)
            || StrikeTime >= 2)
        {
            actor.ChangeState(new FollowState());
        }
    }

    public void OnExitState(object action)
    {
        var actor = (ShiActor) action;
    }

    private void GetSpeed()
    {
        
    }
}
