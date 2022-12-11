using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : IState
{
    private float JumpTime;
    
    public void OnEnterState(object action)
    {
        //Debug.Log("IsJump");
        JumpTime = 0;
        var actor = (PlayerActor) action;
        actor.rig.velocity += Vector2.up * actor._playerData.JumpForce;
        

    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor._animatorManager.playJump();
        actor.PlayerMove();
        actor.HitDetected();
        JumpTime += Time.deltaTime;
        
        if (Physics2D.OverlapCircle(actor.transform.position - actor._playerData.JumpAera, actor._playerData.jumpRange, actor.jumpfloor) 
            && JumpTime >= 0.3f)
        {
            actor.onTheMoveDetected();
        }
        
        if (JumpTime >= 0.5f)
        {
            actor.changeState(new DropState());
        }

        if (Input.GetButtonDown("XKey"))
        {
            actor.changeState(new AttackState());
        }




    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
    
}
