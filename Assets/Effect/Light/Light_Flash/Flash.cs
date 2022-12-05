using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flash : MonoBehaviour
{
    [Header("設定燈光")]
    [SerializeField] public Light2D Light2D;
    [Header("設定最大亮度")]
    [SerializeField] public float Light_Hight;
    [Header("設定最小亮度")]
    [SerializeField] public float Light_Low;
    [Header("設定變化速度")]
    [SerializeField] public float Flash_Speed;
    [Header("當前亮度")]
    [SerializeField] public float Light_now;
    [Header("最新亮度")]
    [SerializeField] public float Light_new;
    [Header("是否開燈")]
    [SerializeField] public bool is_Lighting = true;
    [Header("設定閃爍速度")]
    [SerializeField] public float flashtime;
    public bool LightSwitch = true;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        time();
        GetLight();
        Lightflash();
        SetLight();

    }
    void Lightflash()
    {
        if (is_Lighting == true)
        {
            Light_new = Mathf.Lerp(Light_now, Light_Hight, Flash_Speed * Time.deltaTime);

        }
        if (is_Lighting == false)
        {
            Light_new = Mathf.Lerp(Light_now, Light_Low, Flash_Speed * Time.deltaTime);

        }
    }

    void SetLight()
    {
        Light2D.intensity = Light_new;
    }
    void GetLight()
    {
        Light_now = Light2D.intensity;
    }
    void time()
    {
        delta += Time.deltaTime;
        if (delta >= flashtime)
        {
            is_Lighting = !is_Lighting;
            delta = 0;
        }
    }

}


