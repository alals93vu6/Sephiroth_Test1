using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using Project.Player;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("狀態")]
    [SerializeField] private IState CurrenState = new IdleState();
    [SerializeField] public Rigidbody2D rig;
    [SerializeField] private bool HitCD;

    [Header("數值")] 
    [SerializeField] public PlayerData _playerData;

    [Header("Layer")]
    [SerializeField] public LayerMask jumpfloor;
    [SerializeField] public LayerMask HitObj;

    [Header("物件")]
    [SerializeField] public PlayerAnimatorManager _animatorManager ;
    [SerializeField] private Vine_Actor _vineActor;
    [SerializeField] private ShiActor _shiActor;
    [SerializeField] public PlayerFettle _playerFettle;
    [SerializeField] public WeaponAnimatorManager _weaponAnimator;
    //[SerializeField] public MonsterGeneral _monsterGeneral;
    [SerializeField] private GameObject AttackDetected;
    
    void Start()
    {
        changeState(new IdleState());
        rig = GetComponent<Rigidbody2D>();
        _animatorManager = FindObjectOfType<PlayerAnimatorManager>();
        _weaponAnimator = FindObjectOfType<WeaponAnimatorManager>();
        _vineActor = FindObjectOfType<Vine_Actor>();
        _shiActor = FindObjectOfType<ShiActor>();
        _playerFettle = FindObjectOfType<PlayerFettle>();
        //_monsterGeneral = FindObjectOfType<MonsterGeneral>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrenState.OnStayState(this);
        //HitDetected();
        OnPlayerConnect();
        AttackAreaSet();
    }

    public void PlayerMove()
    {
        if(Input.GetAxis("Horizontal") >= 0.2f)
        {
            _animatorManager.flipPlayer(2);
        }
        else if(Input.GetAxis("Horizontal") <= 0.2f)
        {
            _animatorManager.flipPlayer(1);
        }
        
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") *  _playerData.runSpeed, rig.velocity.y);
        
    }

    public void onTheMoveDetected()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            changeState(new MoveState());
        }
        else
        {
            changeState(new IdleState());
        }
    }


    public async void onPlayerDash(float DashForce)
    {
        if (_animatorManager._spriteRenderer.flipX)
        {
            rig.AddForce(new Vector2(DashForce,0) , ForceMode2D.Impulse);
        }
        else
        {
            rig.AddForce(new Vector2(-DashForce,0) , ForceMode2D.Impulse);
        }

        await Task.Delay(600);
            
        if(Physics2D.OverlapCircle(transform.position - _playerData.JumpAera,_playerData.jumpRange, jumpfloor))
        {
            rig.velocity = Vector2.zero;
        }
        onTheMoveDetected();

    }

    public void HitDetected()
    {
        if (Physics2D.OverlapBox(this.transform.position -_playerData.hitboxAera, _playerData.hitbox,0, 65536) && !HitCD)
        {
            //rig.velocity = Vector2.zero;
            changeState(new HitState());
            GetHitCD();
        }
    }

    public void GetDamage()
    {
        EventBus.Post(new PlayerGetHitDetected());
    }

    private async void GetHitCD()
    {
        HitCD = true;
        await Task.Delay(2000);
        HitCD = false;
        
    }

    public void OnPlayerConnect()
    {
        if (_shiActor.SummonON)
        {
            if(Input.GetButtonDown("WeaponConnect"))
            {
                _vineActor.IsCconcatenation = true;
                _weaponAnimator.PlayConnect();
               
            } 
           
            if(Input.GetButtonUp("WeaponConnect"))
            {
                _vineActor.IsCconcatenation = false;
                _weaponAnimator.PlayDisConnect();
            }
        }
        else
        {
            _vineActor.IsCconcatenation = false;
            _weaponAnimator.PlayDisConnect();
        }
    }

    public void AttackAreaSet()
    {
        
        
        if(Input.GetAxis("Horizontal") >= 0.2f)
        {
            AttackDetected.transform.position = this.transform.position +_playerData.AttackAeraR;
        }

        if(Input.GetAxis("Horizontal") <= -0.2f)
        {
            AttackDetected.transform.position = this.transform.position +_playerData.AttackAeraL;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position -_playerData.JumpAera,_playerData.jumpRange);
        Gizmos.DrawWireCube(this.transform.position -_playerData.hitboxAera,_playerData.hitbox);
        //Gizmos.DrawWireCube(this.transform.position - _playerData.HitDetected,_playerData.hitDetectedbox);
    }

    public void changeState(IState nextState)
    {
        //Debug.Log("StateChange");
        CurrenState.OnExitState(this);
        nextState.OnEnterState(this);
        CurrenState = nextState;
    }
    
}
