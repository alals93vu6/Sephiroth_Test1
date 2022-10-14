using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("狀態")]
    [SerializeField] Rigidbody2D rig;
    [SerializeField] public bool IsJump;
    [SerializeField] public bool IsSquat;
    [SerializeField] public bool IsMove;
    [SerializeField] public bool IsRight;
    [SerializeField] public bool WeaponSummon;
    [SerializeField] public bool WeaponIsRight;
    [SerializeField] private bool DashCD;
    [SerializeField] private IState CurrenState = new IdeoState();

    [Header("數值")]
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpRange;
    [SerializeField] private float JumpFouce;
    [SerializeField] private float BrakesFouce;
    [SerializeField] public float DashFouce;

    [SerializeField] private float H;
    [SerializeField] private float V;

    [Header("Layer")]
    [SerializeField] private LayerMask Jumpfloor;
    [SerializeField] private LayerMask Landfloor;
    
    [Header("物件")]
    [SerializeField] public GameObject JumpArea;
    [SerializeField] private Transform WeaponPos;
    
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
        WeaponPosDetected();
        
        UpdateTest();
    }

    public void connecttest()
    {
        //Debug.Log("AAAAA");
    }
    
    private void UpdateTest()
    {
        OnPlayerConnect();
        OnPlayerCallWeapon();
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
        
        
        if(Input.GetAxisRaw("HorizontalA") <= -0.01f  || Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2 (-1 * RunSpeed, rig.velocity.y);
            transform.localScale = new Vector3(-5f, 5f, 5f);
            IsRight = false;

        }

        if(Input.GetAxisRaw("HorizontalA") >= 0.01f || Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2 (1 * RunSpeed, rig.velocity.y);
            transform.localScale = new Vector3(5f, 5f, 5f);
            IsRight = true;
        }

        if (Input.GetAxis("HorizontalA") == 0f && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2 (0 * RunSpeed, rig.velocity.y);
        }

        
        //到時候記得依角色大小改Scale
    }

    public void PlayerAttacking()
    {
        if (Input.GetButtonDown("XKey"))
        {
            ChangeState(new AttackState());
        }
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
        if (!IsRight)
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
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,Jumpfloor))
        {
            IsJump = false;

        }
        else { IsJump = true; ChangeState(new DropState()); }
    }
    
    //||
    //Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,LandFool)

    public void PlayerDownWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,Jumpfloor))
        {
            IsJump = false;
            //Debug.Log("著陸");
            ChangeState(new IdeoState());
        }
        else { IsJump = true;}
    }

    public void OnPlayerConnect()
    {
        if(Input.GetButtonDown("WeaponConnect"))
        {
            ChangeState(new ConnectState());
        }
    }

    public void ConnectDetected()
    {
        if(!Input.GetButton("WeaponConnect"))
        {
            ChangeState(new IdeoState());
        }
    }

    public void OnPlayerCallWeapon()
    {
        if (Input.GetButtonDown("CallWeapon"))
        {
            Debug.Log("CallWeapon!!");
        }
    }

    public void WeaponStateChang()
    {
        if(WeaponSummon)
        {
            WeaponSummon = false;
        }
        else
        {
            WeaponSummon = true;
        }
    }

    private void WeaponPosDetected()
    {
        if (WeaponPos.position.x >= this.transform.position.x)
        {
            WeaponIsRight = true;
        }
        else
        {
            WeaponIsRight = false;
        }
    }

    public async void OnPlayerDash()
    {
        if (!DashCD)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("BKey"))
            {
                OnDashCD();
                ChangeState(new DashState());
                if (!IsRight)
                {
                    rig.AddForce(new Vector2(-DashFouce,0) , ForceMode2D.Impulse);
                }
                else
                {
                    rig.AddForce(new Vector2(DashFouce,0) , ForceMode2D.Impulse);
                }
            
                await Task.Delay(500);
                    
                StopSlip();
                ChangeState(new IdeoState());
            }
        }

        
    }

    private async void OnDashCD()
    {
        DashCD = true;
        
        await Task.Delay(800);

        DashCD = false;
    }

    public void OnSquatReady()
    {
        rig.velocity = Vector2.zero;
    }


    public async void OnPlayerDropFloor()
    {
        if (Input.GetAxis("VerticalA") <= -0.6f && Input.GetButtonDown("AKey"))
        {
            LandFloor.instance.OnPlayerFloorCross();
            
            
            await Task.Delay(100);
            
            ChangeState(new DropState());
            
        }
        
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            LandFloor.instance.OnPlayerFloorCross();
            
            await Task.Delay(100);
            
            ChangeState(new DropState());
            
        }
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
