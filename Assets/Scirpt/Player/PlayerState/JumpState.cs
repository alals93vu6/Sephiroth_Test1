using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : IState
{
    private float JumpTime;
    
    public void OnEnterState(object action)
    {
        Debug.Log("IsJump");
        JumpTime = 0;
        var actor = (PlayerActor) action;
        actor.rig.velocity += Vector2.up * actor.JumpForce;
        
        
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        actor.PlayerMove();
        JumpTime += Time.deltaTime;
        
        if (Physics2D.OverlapCircle(actor.transform.position - actor.JumpAera, actor.jumpRange, actor.jumpfloor) 
           )
        {
            if (actor.H != 0)
            {
                actor.changeState(new MoveState());
            }
            else
            {
                actor.changeState(new IdleState());
            }
        }
        /*
        if (JumpTime >= 1f)
        {
            
        }
        */



    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }
    
}
