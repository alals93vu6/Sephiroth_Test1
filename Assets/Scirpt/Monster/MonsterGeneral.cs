using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyState
{
    PatrolState,
    ChaseState,
    AttackState,
    IdleState,
    HitState,
    DeadState,
        
}
public class MonsterGeneral : MonoBehaviour
{

    public EnemyState MEnemy = EnemyState.PatrolState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual  void Update()
    {
        
        if(Physics2D.OverlapBox((this.transform.position),new Vector2(.35f,0.75f),0,8192))
        {
            Debug.Log("AAA");
        }
        switch (MEnemy)
        {
            case EnemyState.PatrolState:
                OnPatrol();
                break;
            case EnemyState.ChaseState:
                OnChase();
                break;
            case EnemyState.AttackState:
                OnAttack();
                break;
            case EnemyState.IdleState:
                OnIdle();
                break;
            case EnemyState.HitState:
                break;
            case EnemyState.DeadState:
                break;
                
        }
        
    }


    public virtual void OnPatrol()
    {
        Debug.Log("BBB");
    }

    public virtual void OnChase()
    {
        
    }

    public virtual void OnAttack()
    {
        
    }

    public virtual void OnIdle()
    {
        
    }

    public virtual void OnHit()
    {
        
    }
    
    public async void OnDead()
    {
        this.gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        await Task.Delay(500);
        Destroy(this.gameObject);
    }
    
}
