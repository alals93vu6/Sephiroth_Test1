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
    [SerializeField] private Vine_Actor _vineActor;
    [SerializeField] private ShiActor _shiActor;
    [SerializeField] private PlayerFettle _playerFettle;
    
    void Start()
    {
        changeState(new IdeoState());
        rig = GetComponent<Rigidbody2D>();
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


    private void onDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(JumpArea.transform.position,JumpRange);
    }

    public void changeState(IState nextState)
    {
        //Debug.Log("StateChange");
        CurrenState.OnExitState(this);
        nextState.OnEnterState(this);
        CurrenState = nextState;
    }
    
}
