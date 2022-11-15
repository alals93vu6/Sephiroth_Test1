using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("設定消失渲染")]
    [SerializeField] public Material DisappearMaterial;
    [Header("是否消失")]
    [SerializeField] public bool Disappear_is = false; //正常出現
    [Header("當前消失進度")]
    [SerializeField] public float Disappear_now;
    [Header("消失進度")]
    [SerializeField] public float Disappear_new;
    [Header("消失速度")]
    [SerializeField] public float Disappear_Speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        DisappearMaterial.SetFloat("IsDisappear", 1);
    }

    // Update is called once per frame
    void Update()
    {
        GetDisappear();
        disappear_lerp_down();
        disappear_lerp_up();
        SetDisappear();
    }
    void GetDisappear()
    {
        Disappear_now = DisappearMaterial.GetFloat("IsDisappear");
    }

    void SetDisappear()
    {
        DisappearMaterial.SetFloat("IsDisappear", Disappear_new);
    }
    void disappear_lerp_down()
    {
        if (Disappear_is == true)
        {
            Disappear_new = Mathf.Lerp(Disappear_now, 0f, Disappear_Speed * Time.deltaTime);
        }
    }
    void disappear_lerp_up()
    {
        if (Disappear_is == false)
        {
            Disappear_new = Mathf.Lerp(Disappear_now, 1f, Disappear_Speed * Time.deltaTime);
        }
    }

}
