using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IState
{
    public void OnEnterState(object action)
    {
        PlayerAnimatorManager.instance.PlayDash();
    }

    public void OnStayState(object action)
    {
        
    }

    public void OnExitState(object action)
    {
        
    }
}
