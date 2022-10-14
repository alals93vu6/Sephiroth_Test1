using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class AttackState : IState
{
    public void OnEnterState(object action)
    {
        PlayerAnimatorManager.instance.PlayAttack();
        EventBus.Post(new PlayerAttackDetected());
    }

    public async void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        
        //actor.PlayerMove();
        actor.PlayerJumpWhether();
        
        await Task.Delay(450);
        if (Input.GetAxis("HorizontalA") == 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            actor.ChangeState(new IdeoState());
        }
        else {actor.ChangeState(new MoveState());}
        
    }

    public void OnExitState(object action)
    {
        
    }
}
