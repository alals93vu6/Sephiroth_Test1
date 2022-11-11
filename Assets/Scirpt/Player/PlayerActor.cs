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
    [SerializeField] private float jumpRange;
    [SerializeField] private Vector3 JumpAera = new Vector3(0, 0, 0);
    [SerializeField] public float JumpForce;
    [SerializeField] public float H;
    [SerializeField] public float V;

    [Header("Layer")]
    [SerializeField] private LayerMask jumpfloor;

    [Header("物件")]
    [SerializeField] private Transform weaponPos;
    [SerializeField] private PlayerAnimatorManager _animatorManager ;
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
    }

    public void PlayerMove()
    {
        float MoveHorizontal = H;
        
        if(H >= 0.2f)
        {
            _animatorManager.FlipPlayer(2);
        }
        else if(H <= 0.2f)
        {
            _animatorManager.FlipPlayer(1);
        }
        
        rig.velocity = new Vector2(MoveHorizontal * runSpeed, rig.velocity.y);
        
    }

    public void TEst()
    {
        Debug.Log("AAA");
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position - JumpAera,jumpRange);
    }

    public void changeState(IState nextState)
    {
        //Debug.Log("StateChange");
        CurrenState.OnExitState(this);
        nextState.OnEnterState(this);
        CurrenState = nextState;
    }
    
}
