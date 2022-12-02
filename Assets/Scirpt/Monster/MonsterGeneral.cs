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
    [Header("數值")]
    [SerializeField] public int maxHP;
    [SerializeField] public int HP;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float pointTo = 1f;
    [SerializeField] public float detectedRange;
    [SerializeField] public Vector2 Size;
    public float movetime;
    [SerializeField] public Vector3 rightDetected = new Vector3(0, 0, 0);
    [SerializeField] public Vector3 LeftDetected = new Vector3(0, 0, 0);
    
    [Header("物件")]
    [SerializeField] public LayerMask floor;
    
    [Header("狀態")]
    [SerializeField] public Rigidbody2D enemyrig;
    
    public EnemyState MEnemy = EnemyState.PatrolState;
    // Start is called before the first frame update
    public virtual void  Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    public virtual  void Update()
    {
        movetime += Time.deltaTime;
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
                OnHit();
                break;
            case EnemyState.DeadState:
                OnDead();
                break;
                
        }
        
    }


    public virtual void OnPatrol()
    {
        enemyrig.velocity = new Vector2(pointTo * moveSpeed, enemyrig.velocity.y);
    }

    public virtual void OnChase()
    {
        
    }

    public virtual void OnAttack()
    {
        
    }

    public async virtual void OnIdle()
    {
        await Task.Delay(2000);
        MEnemy = EnemyState.PatrolState;
    }

    public virtual void OnHit()
    {
        
    }
    
    public async void OnDead()
    {
        this.gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        await Task.Delay(500);
        this.gameObject.SetActive(false);
    }

    public void OnReLoad()
    {
        this.gameObject.SetActive(true);
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        MEnemy = EnemyState.PatrolState;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position - rightDetected,detectedRange);
        Gizmos.DrawWireSphere(this.transform.position - LeftDetected,detectedRange);
        Gizmos.DrawWireCube(this.transform.position,Size);
    }

}
