using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ShiActor : MonoBehaviour
{
    [Header("數值")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float PlayerX;
    [SerializeField] private float NowShiGapPosX , NowShiGapPosY;
    [SerializeField] private float XAxis;

    [Header("物件")] 
    [SerializeField] private GameObject PlayerNowPos;
    
    [Header("狀態")]
    [SerializeField] private Rigidbody2D Shirig;
    [SerializeField] private IState currenState = new FollowState();

    // Start is called before the first frame update
    void Start()
    {
        Shirig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currenState.OnStayState(this);
       
    }
    
    public void SummonsShi()
    {
        Shirig.velocity = Vector2.zero;
        EventBus.Post(new PlayerCallShiDetected());
    }

    public void SummonsPosMaxDetection()
    {
        NowShiGapPosX = Mathf.Abs(this.gameObject.transform.position.x - PlayerNowPos.transform.position.x);
        NowShiGapPosY = Mathf.Abs(this.gameObject.transform.position.y - PlayerNowPos.transform.position.y);
    }

    public void ShiReTurn()
    {
        EventBus.Post(new ShiReturnDetected());
    }

    public void ShiFollowMove()
    {
        XAxis = Input.GetAxisRaw("HorizontalA");

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
            this.transform.localScale = new Vector2(0.2f, 0.2f);
        }
        else
        {
            this.transform.localScale = new Vector2(-0.2f, 0.2f);
        }
    }

    public void ShiFollowPosMax()
    {
        PlayerX = PlayerNowPos.transform.position.x;

        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, PlayerX - 1.5f, PlayerX + 1.5f), 
            Mathf.Clamp(this.transform.position.y, PlayerNowPos.transform.position.y + 3f, PlayerNowPos.transform.position.y + 3f));
        
        
    }

    public void ChangeState(IState NextState)
    {
        currenState.OnExitState(this);
        NextState.OnEnterState(this);
        currenState = NextState;
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
