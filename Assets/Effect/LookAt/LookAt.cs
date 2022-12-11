using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LookAt : MonoBehaviour
{
    [Header("看向目標")]
    [SerializeField] public GameObject LookAtGameObject;
    public GameObject otherlight;
    public Light2D light2D00;
    public Light2D light2D01;

    public float Light_now;
    public float Light_new;
    public float Speed;
    public bool is_link = false;
    void Update()
    {
        GetLight();
        link();
        SetLight();
        this.transform.right = LookAtGameObject.transform.position - this.transform.position;
        otherlight.transform.right = LookAtGameObject.transform.position - this.transform.position;
    }
    void link()
    {
        if (!is_link)
        {
            Light_new = Mathf.Lerp(Light_now, 0, Speed * Time.deltaTime);
        }
        if (is_link)
        {
            Light_new = Mathf.Lerp(Light_now, 0.25f, Speed * Time.deltaTime);
        }
    }
    void SetLight()
    {
        light2D00.intensity = Light_new;
        light2D01.intensity = Light_new;
    }
    void GetLight()
    {
        Light_now = light2D01.intensity;
    }

}
