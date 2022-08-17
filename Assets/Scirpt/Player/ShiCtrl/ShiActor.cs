using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiActor : MonoBehaviour
{
    [Header("數值")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float PlayerX, PlayerY;
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
            
        }
        else
        {
            ShiFollowMove();
            ShiFollowPosMax();
        }
    }
    
    private void SummonsShi()
    {
        IsSummons = true;
    }

    private void SummonsPosMax()
    {
        IsSummons = false;
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
        PlayerY = PlayerNowPos.transform.position.y;
        
        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, PlayerX - 1.5f, PlayerX + 1.5f), 
            Mathf.Clamp(this.transform.position.y, PlayerNowPos.transform.position.y + 1.4f, PlayerNowPos.transform.position.y + 1.4f));
    }

}
