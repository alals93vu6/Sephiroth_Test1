using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyState : IState
{
    public void OnEnterState(object action)
    {
        var actor = (ShiActor) action;
        Debug.Log("Dizzy...");
    }

    public void OnStayState(object action)
    {
        var actor = (ShiActor) action; 
    }

    public void OnExitState(object action)
    {
        var actor = (ShiActor) action;
    }
}
