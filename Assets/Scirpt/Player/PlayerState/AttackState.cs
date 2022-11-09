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
        
    }

    public async void OnStayState(object action)
    {
        var actor = (PlayerActor) action;
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
