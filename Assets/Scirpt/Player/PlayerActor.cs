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
    [SerializeField] public bool IsSquat;
    [SerializeField] public bool IsMove;
    [SerializeField] private IState CurrenState = new IdeoState();
    public bool Ideo;
    
    [Header("數值")]
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpRange;
    [SerializeField] private float JumpFouce;
    [SerializeField] private float BrakesFouce;

    [SerializeField] private float H;
    [SerializeField] private float V;

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
        H = Input.GetAxis("HorizontalA");
        V = Input.GetAxis("VerticalA");
        
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

        //rig.velocity = new Vector2 (Input.GetAxis("HorizontalA") * RunSpeed, rig.velocity.y);
        
        
        if(Input.GetAxisRaw("HorizontalA") <= -0.01f  || Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2 (-1 * RunSpeed, rig.velocity.y);
            transform.localScale = new Vector3(-5f, 5f, 5f);
            
        }

        if(Input.GetAxisRaw("HorizontalA") >= 0.01f || Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2 (1 * RunSpeed, rig.velocity.y);
            transform.localScale = new Vector3(5f, 5f, 5f);
        }

        if (Input.GetAxis("HorizontalA") == 0f && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2 (0 * RunSpeed, rig.velocity.y);
        }

        
        //到時候記得依角色大小改Scale
    }

    public void OnPlayerJump()
    {
        if(Input.GetButtonDown("AKey") || Input.GetKeyDown(KeyCode.Space) && !IsJump)
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

    public void OnFloorCross()
    {
        
    }

    public void OnPlayerSquatDetect()
    {
        if (Input.GetAxis("VerticalA") <= -0.6f && !Input.GetKey(KeyCode.S))
        {
            IsSquat = true;
        }
        
        if (Input.GetAxis("VerticalA") == 0 && Input.GetKey(KeyCode.S))
        {
            IsSquat = true;
        }
        
        if (Input.GetAxis("VerticalA") >= -0.6 && !Input.GetKey(KeyCode.S))
        {
            IsSquat = false;
        }
        
        if (Input.GetAxis("VerticalA") == 0 && !Input.GetKey(KeyCode.S))
        {
            IsSquat = false;
        }

        if (IsSquat)
        {
            ChangeState(new SquatState());
        }
    }

    public void OnPlayerMoveDetect()
    {
        if (Mathf.Abs(Input.GetAxis("HorizontalA")) >= 0.55f && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            IsMove = true;
        }

        if (Input.GetAxis("HorizontalA") == 0 && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            IsMove = true;
        }

        if (Input.GetAxis("HorizontalA") == 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            IsMove = false;
        }
    }

    public void StopSlip()
    {
        rig.velocity = Vector2.zero;
    }

    public void PlayerJumpWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,JumpFloor))
        {
            IsJump = false;

        }
        else { IsJump = true; ChangeState(new DropState()); }
    }
    
    //||
    //Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,LandFool)

    public void PlayerDownWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,JumpFloor))
        {
            IsJump = false;
            //Debug.Log("著陸");
            ChangeState(new IdeoState());
        }
        else { IsJump = true;}
    }

    public void PlayerDash()
    {
        
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
