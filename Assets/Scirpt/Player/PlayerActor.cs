using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("狀態")]
    [SerializeField] public Rigidbody2D rig;
    [SerializeField] private IState CurrenState = new IdleState();

    [Header("數值")]
    [SerializeField] private float runSpeed;
    [SerializeField] public float jumpRange;
    [SerializeField] public Vector3 JumpAera = new Vector3(0, 0, 0);
    [SerializeField] public Vector3 hitboxAera = new Vector3(0, 0, 0);
    [SerializeField] public Vector2 hitbox = new Vector2(0, 0);
    [SerializeField] public float JumpForce;
    [SerializeField] public float H;
    [SerializeField] public float V;

    [Header("Layer")]
    [SerializeField] public LayerMask jumpfloor;

    [Header("物件")]
    [SerializeField] public PlayerAnimatorManager _animatorManager ;
    [SerializeField] private Vine_Actor _vineActor;
    [SerializeField] private ShiActor _shiActor;
    [SerializeField] private PlayerFettle _playerFettle;
    
    void Start()
    {
        changeState(new IdleState());
        rig = GetComponent<Rigidbody2D>();
        _animatorManager = FindObjectOfType<PlayerAnimatorManager>();
        _vineActor = FindObjectOfType<Vine_Actor>();
        _shiActor = FindObjectOfType<ShiActor>();
        _playerFettle = FindObjectOfType<PlayerFettle>();
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        
        CurrenState.OnStayState(this);
        OnPlayerConnect();
    }

    public void PlayerMove()
    {
        float MoveHorizontal = H;
        
        if(H >= 0.2f)
        {
            _animatorManager.flipPlayer(2);
        }
        else if(H <= 0.2f)
        {
            _animatorManager.flipPlayer(1);
        }
        
        rig.velocity = new Vector2(MoveHorizontal * runSpeed, rig.velocity.y);
        
    }

    public void onTheMoveDetected()
    {
        if (H != 0)
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
            
        if(Physics2D.OverlapCircle(transform.position - JumpAera, jumpRange, jumpfloor))
        {
            rig.velocity = Vector2.zero;
        }
        onTheMoveDetected();

    }
    
    public void OnPlayerConnect()
    {
        if (_shiActor.SummonON)
        {
            if(Input.GetButtonDown("WeaponConnect"))
            {
                _vineActor.IsCconcatenation = true;
               
            } 
           
            if(Input.GetButtonUp("WeaponConnect"))
            {
                _vineActor.IsCconcatenation = false;
            }
        }
        else
        {
            _vineActor.IsCconcatenation = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position - JumpAera,jumpRange);
        Gizmos.DrawWireCube(this.transform.position - hitboxAera,hitbox);
    }

    public void changeState(IState nextState)
    {
        //Debug.Log("StateChange");
        CurrenState.OnExitState(this);
        nextState.OnEnterState(this);
        CurrenState = nextState;
    }
    
}
