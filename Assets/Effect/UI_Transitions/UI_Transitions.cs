using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Transitions : MonoBehaviour
{
    public Animator animator;
    public bool is_start;
    public bool is_end;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Is_Transitions_end",is_end);
        animator.SetBool("Is_Transitions_start",is_start);
    }
}
