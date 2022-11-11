using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : IState
{
    private int TestBool = 2;
    
    public void OnEnterState(object action)
    {
        Debug.Log("IsJump");
        var actor = (PlayerActor) action;
        actor.rig.velocity += Vector2.up * actor.JumpForce;
        
    }

    public void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        if (actor.H == 0)
        {
            actor.changeState(new IdleState());
        }
        else
        {
            actor.changeState(new MoveState());
        }

        
        

    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
    }

    private void stateChange(object action)
    {
        var actor = (PlayerActor) action;
        actor.TEst();
    }
}
