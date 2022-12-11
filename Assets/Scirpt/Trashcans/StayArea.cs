using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayArea : MonoBehaviour
{
    [Header("狀態")]
    [SerializeField] Rigidbody2D StayArearig;
    
    [Header("數值")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float PlayerX, PlayerY;
    [SerializeField] private float XAxis;

    [SerializeField] private GameObject PlayerNowPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StayArearig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AreaMove();
        AreaPosMax();
    }

    private void AreaMove()
    {
        XAxis = Input.GetAxisRaw("HorizontalA");
        
        StayArearig.velocity = new Vector2(-XAxis ,0) * MoveSpeed;
        
        //StayArearig.AddForce(new Vector2(-XAxis, 0) * MoveSpeed, ForceMode2D.Impulse);
    }

    private void AreaPosMax()
    {
        PlayerX = PlayerNowPos.transform.position.x;
        PlayerY = PlayerNowPos.transform.position.y;
        
        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, PlayerX - 1.5f, PlayerX + 1.5f),
            this.transform.position.y);
    }
}
