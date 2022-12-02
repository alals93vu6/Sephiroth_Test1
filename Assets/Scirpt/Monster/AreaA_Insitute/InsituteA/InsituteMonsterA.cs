using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsituteMonsterA : MonsterGeneral
{
    
    public override void Start()
    {
        base.Start();
        enemyrig = GetComponent<Rigidbody2D>();
        
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("VAR");
    }
    public override void OnPatrol()
    {
        base.OnPatrol();
        
    }

    public override void OnChase()
    {
        base.OnChase();
        
    }
}
