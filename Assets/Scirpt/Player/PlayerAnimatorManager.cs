using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    #region Instance
    static public PlayerAnimatorManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    [Header("狀態")]
    [SerializeField] public Animator AN;

    // Start is called before the first frame update
    void Start()
    {
        AN = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayIdeo()
    {
        AN.SetBool("IsIdeo",true);
    }

    public void ExitIdeo()
    {
        AN.SetBool("IsIdeo",false);
    }

    public void PlayAttack()
    {
        //AN.Play("PlayerAttackTest");
        Debug.Log("Attack");
    }

    public void PlayRun()
    {
        AN.Play("PlayerRun");
    }

    public void PlayDash()
    {
        AN.Play("PlayerDash");
    }

    public void PlayStopMove()
    {
        AN.Play("PlayerStopMove");
    }
    
    public void PlayJump()
    {
        AN.Play("PlayerJump");
    }
    
    public void PlayDrop()
    {
        AN.Play("PlayerDrop");
    }
    
}
