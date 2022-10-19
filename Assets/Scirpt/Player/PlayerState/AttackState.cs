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
        //Debug.Log("IsAttack");
        PlayerAnimatorManager.instance.PlayAttack();
        EventBus.Post(new PlayerAttackDetected());
    }

    public async void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
        
        //actor.PlayerMove();
        //actor.PlayerJumpWhether();
        
        await Task.Delay(450);

        if (!actor.IsJump == false)
        {
            actor.ChangeState(new DropState());
            LOGA();
        }
        else if(actor.IsJump == false)
        {
           LOGB();
            if ( Mathf.Abs(Input.GetAxis("HorizontalA")) >= 0.55f || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
           {
               actor.ChangeState(new MoveState());
               
           }
           else {actor.StopSlip(); actor.ChangeState(new IdeoState());} 
        }

    }

    public void OnExitState(object action)
    {
        var actor = (PlayerActor) action;
        //actor.StopSlip();
    }

    private void LOGA()
    {
      Debug.Log("AAA");  
    }
    
    private void LOGB()
    {
        Debug.Log("bbb");  
    }
    
    private void LOGC()
    {
        Debug.Log("ccc");  
    }
}
