using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine_ideo_end : Vine_IState
{
    public void OnEnterState_Vine(object action)
    {
        Debug.Log("Vine_ideo_end");
    }
    public void OnStayState_Vine(object action)
    {

        var actor = (Vine_Actor)action;
        actor.Vine_IsCconcatenation();
        actor.Vine_length();

        if (actor.IsCconcatenation == false)
        {
            actor.ChangeState_Vine(new Vine_ideo_nothing());
        }
    }
    public void OnExitState_Vine(object action)
    {

    }
}
