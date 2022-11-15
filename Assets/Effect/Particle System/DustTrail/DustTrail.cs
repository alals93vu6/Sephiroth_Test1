using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [Header("特效")]
    [SerializeField] private ParticleSystem DustTrail_particleSystem;
    [Header("待機")]
    [SerializeField] private bool DustTrail_standby = true;
    [Header("左走")]
    [SerializeField] private bool DustTrail_leftWalk = false;
    [Header("右走")]
    [SerializeField] private bool DustTrail_rightWalk = false;
    [Header("煞車")]
    [SerializeField] private bool DustTrail_brakes = false;
    [Header("跳躍")]
    [SerializeField] private bool DustTrail_jump = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
