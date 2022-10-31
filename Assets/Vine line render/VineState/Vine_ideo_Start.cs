using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine_ideo_start : Vine_IState
{
    public void OnEnterState_Vine(object action)
    {
        Debug.Log("Vine_ideo_start");
        var actor = (Vine_Actor)action;
        actor.Vine_value = 0;
    }
    public void OnStayState_Vine(object action)
    {
        var actor = (Vine_Actor)action;
        actor.Vine_IsCconcatenation();
        actor.Vine_length();
        
    }
    public void OnExitState_Vine(object action)
    {

    }
}
