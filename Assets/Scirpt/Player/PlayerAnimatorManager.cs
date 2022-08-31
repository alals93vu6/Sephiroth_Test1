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
    [SerializeField] private Animator AN;

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

    public void PlayRun()
    {
        AN.Play("PlayerRunTest");
    }
    
    public void PlayStopMove()
    {
        AN.Play("PlayerStopMoveTest");
    }
    
}
