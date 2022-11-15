using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine_IdeoState : Vine_IState
{
    public void OnEnterState_Vine(object action)
    {
        Debug.Log("Vine_IState");
    }
    public void OnStayState_Vine(object action)
    {

        var actor = (Vine_Actor)action;
        actor.Vine_IsCconcatenation();
        

        Debug.Log("is ideo");
    }
    public void OnExitState_Vine(object action)
    {

    }
}
