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

    [Header("Layer")]
    [SerializeField] private LayerMask JumpFool;
    
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
        rig.velocity = new Vector2 (Input.GetAxis("HorizontalA") * RunSpeed, rig.velocity.y);

        if(Input.GetAxisRaw("HorizontalA") <= -0.01f )
        {
            transform.localScale = new Vector3(-0.14f, 0.21f, 0.14f);
        }

        if(Input.GetAxisRaw("HorizontalA") >= 0.01f )
        {
            transform.localScale = new Vector3(0.14f, 0.21f, 0.14f);
        }
        /*
        
        */
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

    public void PlayerJumpWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,JumpFool))
        {
            IsJump = false;

        }
        else { IsJump = true; ChangeState(new DropState()); }
    }

    public void PlayerDownWhether()
    {
        if(Physics2D.OverlapCircle(JumpArea.transform.position,JumpRange,JumpFool))
        {
            IsJump = false;
            Debug.Log("著陸");
            ChangeState(new MoveState());
        }
        else { IsJump = true;}
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
