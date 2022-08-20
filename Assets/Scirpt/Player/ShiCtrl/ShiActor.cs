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
    [SerializeField] private float NowShiGapPosx , NowShiGapPosY;
    [SerializeField] private float XAxis;

    [Header("物件")] 
    [SerializeField] private GameObject PlayerNowPos;
    
    [Header("狀態")] 
    [SerializeField] private bool IsSummons;
    [SerializeField] private Rigidbody2D Shirig;

    // Start is called before the first frame update
    void Start()
    {
        Shirig = GetComponent<Rigidbody2D>();
        IsSummons = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSummons)
        {
            SummonsPosMaxDetection();
        }
        else
        {
            ShiFollowMove();
            ShiFollowPosMax();
            
            
            
            if (Input.GetButtonDown("XKey") || Input.GetKeyDown(KeyCode.H))
            {
                
                SummonsShi();
            }
        }
    }
    
    private void SummonsShi()
    {
        IsSummons = true;
        Shirig.velocity = Vector2.zero;
        EventBus.Post(new PlayerCallShiDetected());
    }

    private void SummonsPosMaxDetection()
    {
        NowShiGapPosx = Mathf.Abs(this.gameObject.transform.position.x - PlayerNowPos.transform.position.x);
        NowShiGapPosY = Mathf.Abs(this.gameObject.transform.position.y - PlayerNowPos.transform.position.y);

        if (NowShiGapPosx >= 12 || NowShiGapPosY >= 8) { ShiReTurn();}
    }

    private void ShiReTurn()
    {
        IsSummons = false;
        EventBus.Post(new ShiReturnDetected());
    }

    private void ShiFollowMove()
    {
        XAxis = Input.GetAxisRaw("HorizontalA");
        
        Shirig.velocity = new Vector2(-XAxis ,0) * MoveSpeed;
        
        //StayArearig.AddForce(new Vector2(-XAxis, 0) * MoveSpeed, ForceMode2D.Impulse);
    }
    private void ShiFollowPosMax()
    {
        PlayerX = PlayerNowPos.transform.position.x;

        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, PlayerX - 1.5f, PlayerX + 1.5f), 
            Mathf.Clamp(this.transform.position.y, PlayerNowPos.transform.position.y + 1.4f, PlayerNowPos.transform.position.y + 1.4f));
    }

}
