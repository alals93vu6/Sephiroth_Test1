using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeState : IState
{
    private float StrikeTime;
    private float Speed;
    
    public void OnEnterState(object action)
    {
        var actor = (ShiActor) action;
        StrikeTime = 0f;
        Debug.Log("Strike!");
        actor.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        if (actor._playerActor.IsRight == 1)
        {
            Speed = actor._weaponData.StrikeSpeed;
        }
        else if (actor._playerActor.IsRight == 2)
        {
            Speed = -actor._weaponData.StrikeSpeed;
        }
        else
        {
            if (actor._playerActor.PassState == 1)
            {
                Speed = actor._weaponData.StrikeSpeed;
            }
            else
            {
                Speed = -actor._weaponData.StrikeSpeed;
            }
        }
    }
    public void OnStayState(object action)
    {
        var actor = (ShiActor) action;
        StrikeTime += Time.deltaTime;
        actor.Shirig.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, actor.Shirig.velocity.y);
    }

    public void OnExitState(object action)
    {
        var actor = (ShiActor) action;
    }

    private void GetSpeed()
    {
        
    }
}
