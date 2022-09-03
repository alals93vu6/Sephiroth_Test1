using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("狀態")]
    [SerializeField] Rigidbody2D rig;
    [SerializeField] private bool IsJump;
    [SerializeField] private IState CurrenState = new IdeoState();
    
    [Header("數值")]
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpRange;
    [SerializeField] private float JumpFouce;
    [SerializeField] private float BrakesFouce;

    [Header("Layer")]
    [SerializeField] private LayerMask JumpFloor;
    [SerializeField] private LayerMask LandFloor;
    
    [Header("物件")]
    [SerializeField] GameObject JumpArea;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrenState.OnStayState(this);
    }
    
    public void PlayerMove()
    {
        /*
        float H = Input.GetAxis("HorizontalA");

        if (Mathf.Abs(H) >= 0.6f)
        {
            rig.velocity = new Vector2 (Input.GetAxis("HorizontalA") * RunSpeed, rig.velocity.y);
        }
        
        */
        rig.velocity = new Vector2 (Input.GetAxis("HorizontalA") * RunSpeed, rig.velocity.y);

        if(Input.GetAxisRaw("HorizontalA") <= -0.01f )
        {
            transform.localScale = new Vector3(-7f, 7f, 7f);
        }

        if(Input.GetAxisRaw("HorizontalA") >= 0.01f )
        {
            transform.localScale = new Vector3(7f, 7f, 7f);
        }
        
        //到時候記得依角色大小改Scale
    }

    public void OnPlayerJump()
    {
        if(Input.GetButtonDown("AKey") && !IsJump)
        {
            rig.AddForce(new Vector2 (rig.velocity.x , JumpFouce), ForceMode2D.Impulse);
            ChangeState(new JumpState());
            //Debug.Log("AAA");
        }
    }

    public void OnPlayerStopMove()
    {
        if (this.transform.localScale.x <= 0)
        {
            rig.AddForce(new Vector2(-BrakesFouce,0) , ForceMode2D.Impulse);
        }
        else
        {
            rig.AddForce(new Vector2(BrakesFouce,0) , ForceMode2D.Impulse);
        }
        
        
        Invoke("StopSlip",0.4f);
        
    }

    public void OnPlayerSquatDetect()
    {
        if (Input.GetAxis("VerticalA") <= -0.6f)
        {
            ChangeState(new SquatState());
        }
    }

    private void StopSlip()
    {
        rig.velocity = Vector2.zero;
    }

    public void PlayerJumpWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,JumpFloor)||
           Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,LandFloor))
        {
            IsJump = false;

        }
        else { IsJump = true; ChangeState(new DropState()); }
    }
    
    //||
    //Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,LandFool)

    public void PlayerDownWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,JumpFloor)||
           Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,LandFloor))
        {
            IsJump = false;
            Debug.Log("著陸");
            ChangeState(new IdeoState());
        }
        else { IsJump = true;}
    }

    public void OnSquatReady()
    {
        rig.velocity = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(JumpArea.transform.position,JumpRange);
    }

    public void ChangeState(IState nextState)
    {
        CurrenState.OnExitState(this);
        nextState.OnEnterState(this);
        CurrenState = nextState;
    }
}
