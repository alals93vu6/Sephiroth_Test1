using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    [Header("狀態")]
    [SerializeField] public Animator AN;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        AN = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipPlayer(int flipInt)
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

}
