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

    public void flipPlayer(int flipInt)
    {
        if (flipInt == 1)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void PlayAttack()
    {
        AN.Play("PlayerAttack");
    }

    public void playIdle()
    {
        AN.Play("PlayerIdle");
    }
    
    public void playDead()
    {
        AN.Play("PlayerDeadL");
    }
    
    public void playMove()
    {
        AN.Play("PlayerRun");
    }
    
    public void playHit()
    {
        AN.Play("PlayerHitL");
    }
    
    public void playHeal()
    {
        AN.Play("PlayerHealL");
    }

    public void playBrakes()
    {
        AN.Play("PlayerStopMove");
    }

    public void playJump()
    {
        AN.Play("PlayerJump");
    }
    
    public void playDrop()
    {
        AN.Play("PlayerDrop");
    }
    
    public void playDash()
    {
        AN.Play("PlayerDash");
    }

}
