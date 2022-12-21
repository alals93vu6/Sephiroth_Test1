using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using Project.Player;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ShiActor : MonoBehaviour
{
    [Header("數值")] 
    [SerializeField] public WeaponData _weaponData;

    [Header("物件")] 
    [SerializeField] public GameObject PlayerNowPos;
    [SerializeField] public PlayerActor _playerActor;
    [SerializeField] public WeaponAnimatorManager _weaponAnimator;
    [SerializeField] public LayerMask StrikeLayer;


    [Header("狀態")]
    [SerializeField] public Rigidbody2D Shirig;
    [SerializeField] private IState currenState = new FollowState();
    [SerializeField] public bool SummonCD;
    [SerializeField] public bool SummonON;
    public bool ReadyAttack;

    // Start is called before the first frame update
    void Start()
    {
        Shirig = GetComponent<Rigidbody2D>();
        _playerActor = FindObjectOfType<PlayerActor>();
        _weaponAnimator = FindObjectOfType<WeaponAnimatorManager>();
        ChangeState(new FollowState());
    }

    // Update is called once per frame
    void Update()
    {
        currenState.OnStayState(this);
    }

    public void ShiAttack()
    {
        
    }

    public void SummonsShi()
    {
        Shirig.velocity = Vector2.zero;
        ChangeState(new StrikeState());
        OnSummonCD();
        //EventBus.Post(new CallWeaponDetected());
    }

    public async void OnSummonCD()
    {
        SummonCD = true;

        await Task.Delay(2000);

        SummonCD = false;
    }

    public void WeaponAttack()
    {
        if (ReadyAttack)
        {
            _weaponAnimator.OnWeaponAttack();
        }
    }

    public void SummonsPosMaxDetection()
    {
        _weaponData.NowShiGapPosX = Mathf.Abs(this.gameObject.transform.position.x - PlayerNowPos.transform.position.x);
        _weaponData.NowShiGapPosY = Mathf.Abs(this.gameObject.transform.position.y - PlayerNowPos.transform.position.y);
    }

    public void ShiReTurn()
    {
        ChangeState(new FollowState());
        SummonON = false;
        
        EventBus.Post(new CallBackWeaponDetected());
    }

    public void ShiFollowMove()
    {
        _weaponData.XAxis = Input.GetAxisRaw("Horizontal");

        if (_weaponData.XAxis >= 0.55f)
        {
            Shirig.velocity = new Vector2(-_weaponData.XAxis ,0) * _weaponData.MoveSpeed;
        }
        else
        {
            Shirig.velocity = Vector2.zero;
        }

        //StayArearig.AddForce(new Vector2(-XAxis, 0) * MoveSpeed, ForceMode2D.Impulse);
    }

    public void ShiRotation()
    {
        if (this.transform.position.x <= _weaponData.PlayerX)
        {
            TurnLeft();
        }
        else
        {
            TurnRight();
        }
    }

    public void TurnLeft()
    {
        this.transform.localScale = new Vector2(-0.12f, 0.12f);
    }
    
    public void TurnRight()
    {
        this.transform.localScale = new Vector2(0.12f, 0.12f);
    }

    public void ShiFollowPosMax()
    {
        _weaponData.PlayerX = PlayerNowPos.transform.position.x;

        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, _weaponData.PlayerX - 1f, _weaponData.PlayerX + 2f), 
            Mathf.Clamp(this.transform.position.y, PlayerNowPos.transform.position.y + 1f, PlayerNowPos.transform.position.y + 1f));
        
        
    }

    public void ChangeState(IState NextState)
    {
        currenState.OnExitState(this);
        NextState.OnEnterState(this);
        currenState = NextState;
    }
    

    public float GetNowShiGapPosX()
    {
        return _weaponData.NowShiGapPosX;
    }

    public float GetNowShiGapPosY()
    {
        return _weaponData.NowShiGapPosY;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position + _weaponData.StrikeOffset,_weaponData.StrileRange);
        Gizmos.DrawWireSphere(this.transform.position - _weaponData.StrikeOffset,_weaponData.StrileRange);
        //Gizmos.DrawWireCube(this.transform.position -_playerData.hitboxAera,_playerData.hitbox);
        //Gizmos.DrawWireCube(this.transform.position - _playerData.HitDetected,_playerData.hitDetectedbox);
    }
}
