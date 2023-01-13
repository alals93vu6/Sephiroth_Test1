using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    [Header("狀態")]
    [SerializeField] public Animator AN;
    [SerializeField] public SpriteRenderer _spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        AN = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void PlayAttack(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerAttackR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerAttackL");
        }
    }

    public void playIdle(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerIdleR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerIdleL");
        }
        
    }
    
    public void playDead(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerDeadR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerDeadL");
        }
    }
    
    public void playMove(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerRunR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerRunL");
        }
    }
    
    public void playHit(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerHitR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerHitL");
        }
    }
    
    public void playHeal(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerHealR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerHealL");
        }
    }
/*
    public void playBrakes(int IsRight)
    {
        
        if (IsRight == 1)
        {
            
        }
        if (IsRight == 2)
        {
            
        }
        AN.Play("PlayerStopMove");
    }
*/
    public void playJump(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerJumpR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerJumpL");
        }
    }
    
    public void playDrop(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerDropR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerDropL");
        }
        
    }
    
    public void playDash(int IsRight)
    {
        if (IsRight == 1)
        {
            AN.Play("PlayerDashR");
        }
        if (IsRight == 2)
        {
            AN.Play("PlayerDashL");
        }
    }

}
