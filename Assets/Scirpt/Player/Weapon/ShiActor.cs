using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ShiActor : MonoBehaviour
{
    [Header("數值")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] public float PlayerX;
    [SerializeField] private float NowShiGapPosX , NowShiGapPosY;
    [SerializeField] private float XAxis;
    [SerializeField] public int LogState;

    [Header("物件")] 
    [SerializeField] public GameObject PlayerNowPos;
    [SerializeField] private Transform WeaponPos;
    

    [Header("狀態")]
    [SerializeField] private Rigidbody2D Shirig;
    [SerializeField] private IState currenState = new FollowState();
    [SerializeField] public bool SummonCD;
    [SerializeField] public bool SummonON;
    [SerializeField] public bool IsRight;

    // Start is called before the first frame update
    void Start()
    {
        Shirig = GetComponent<Rigidbody2D>();
        
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
        ChangeState(new SummonState());
        OnSummonCD();
        //EventBus.Post(new CallWeaponDetected());
    }

    public async void OnSummonCD()
    {
        SummonCD = true;

        await Task.Delay(2000);

        SummonCD = false;
    }

    public void SummonsPosMaxDetection()
    {
        NowShiGapPosX = Mathf.Abs(this.gameObject.transform.position.x - PlayerNowPos.transform.position.x);
        NowShiGapPosY = Mathf.Abs(this.gameObject.transform.position.y - PlayerNowPos.transform.position.y);
    }

    public void ShiReTurn()
    {
        ChangeState(new FollowState());
        SummonON = false;
        
        EventBus.Post(new CallBackWeaponDetected());
    }

    public void ShiFollowMove()
    {
        XAxis = Input.GetAxisRaw("Horizontal");

        if (XAxis >= 0.55f)
        {
            Shirig.velocity = new Vector2(-XAxis ,0) * MoveSpeed;
        }
        else
        {
            Shirig.velocity = Vector2.zero;
        }

        //StayArearig.AddForce(new Vector2(-XAxis, 0) * MoveSpeed, ForceMode2D.Impulse);
    }

    public void ShiRotation()
    {
        if (this.transform.position.x <= PlayerX)
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
        this.transform.localScale = new Vector2(0.12f, 0.12f);
    }
    
    public void TurnRight()
    {
        this.transform.localScale = new Vector2(-0.12f, 0.12f);
    }

    public void ShiFollowPosMax()
    {
        PlayerX = PlayerNowPos.transform.position.x;

        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, PlayerX - 1f, PlayerX + 2f), 
            Mathf.Clamp(this.transform.position.y, PlayerNowPos.transform.position.y + 1f, PlayerNowPos.transform.position.y + 1f));
        
        
    }

    public void ChangeState(IState NextState)
    {
        currenState.OnExitState(this);
        NextState.OnEnterState(this);
        currenState = NextState;
    }

    public void SummonPosition()
    {
        this.transform.position = WeaponPos.position;
    }

    public float GetNowShiGapPosX()
    {
        return NowShiGapPosX;
    }

    public float GetNowShiGapPosY()
    {
        return NowShiGapPosY;
    }

}
