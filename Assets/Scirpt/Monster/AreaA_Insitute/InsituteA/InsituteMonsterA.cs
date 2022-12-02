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
        enemyrig.velocity = new Vector2(pointTo * moveSpeed, enemyrig.velocity.y);
        movetime += Time.deltaTime;
        ChangePointTO();
    }

    public override void OnChase()
    {
        base.OnChase();
        
    }
    
    private void ChangePointTO()
    {
        if(!Physics2D.OverlapCircle((transform.position - rightDetected), detectedRange,floor))
        {
            pointTo = -1;
            transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
            movetime = 0;
        }
        
        if(!Physics2D.OverlapCircle((transform.position - LeftDetected), detectedRange,floor))
        {
            pointTo = 1;
            transform.localScale = new Vector3(-1.8f, 1.8f, 1.8f);
            movetime = 0;
        }
        
        if (movetime >= 9)
        {
            movetime = 0;
            if (pointTo == 1)
            {
                pointTo = -1;
                transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
            }
            else
            {
                pointTo = 1;
                transform.localScale = new Vector3(-1.8f, 1.8f, 1.8f);
            }
        }
    }
}
