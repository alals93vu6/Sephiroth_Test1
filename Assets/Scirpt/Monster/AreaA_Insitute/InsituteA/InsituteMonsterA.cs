using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsituteMonsterA : MonsterGeneral
{
    
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("VAR");
    }
    public override void OnPatrol()
    {
        base.OnPatrol();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MEnemy = EnemyState.ChaseState;
        }
    }

    public override void OnChase()
    {
        base.OnChase();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MEnemy = EnemyState.PatrolState;
        }
    }
}
