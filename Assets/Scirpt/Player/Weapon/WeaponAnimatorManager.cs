using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator _weaponAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _weaponAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayConnect()
    {
        _weaponAnimator.Play("WeaponSummon");
        _weaponAnimator.SetBool("IsConnect",true);
    }

    public void PlayDisConnect()
    {
        _weaponAnimator.SetBool("IsConnect",false);
    }
}
