using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Link : MonoBehaviour
{
    [Header("主角連結點")]
    [SerializeField] public Light2D Link_player;
    [Header("招喚物連結點")]
    [SerializeField] public Light2D Link_summoner;
    [Header("最大連接數值")]
    [SerializeField] public float Max_linkpoint;
    [Header("當前連結數值")]
    [SerializeField] public float Now_linkpoint;
    [Header("百分比")]
    [SerializeField] public float Link_percentage;
    [Header("為連接顏色")]
    [SerializeField] public Color Color_standby;
    [Header("穩定顏色")]
    [SerializeField] public Color Color_Stablize;
    [Header("過半顏色")]
    [SerializeField] public Color Color_link50;
    [Header("警告顏色")]
    [SerializeField] public Color Color_link15;

    Color New_colorPoint;
    Color Now_colorPoint;

    public bool is_Linking = false;
    bool is_Stablize = false;
    bool is_50 = false;
    bool is_15 = false;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Get_Color();
        percentage();
        Link_judge();
        Set_Coloe();
    }
    void percentage()
    {
        Link_percentage = Mathf.Round((100 / Max_linkpoint) * Now_linkpoint);

        if (Link_percentage >= 50)
        {
            is_Stablize = true;
            is_50 = false;
            is_15 = false;
        }
        if (Link_percentage <= 50 && Link_percentage >= 15)
        {
            is_Stablize = false;
            is_50 = true;
            is_15 = false;
        }
        if (Link_percentage <= 15)
        {
            is_Stablize = false;
            is_50 = false;
            is_15 = true;
        }
    }
    void Link_judge()
    {
        if (!is_Linking) //非連線
        {
            Debug.Log("非連線中");
            New_colorPoint = Color.Lerp(Now_colorPoint, Color_standby, 3 * Time.deltaTime);
        }

        if (is_Linking)  //連線
        {
            Debug.Log("連線中");
            if (is_Stablize)
            {
                New_colorPoint = Color.Lerp(Now_colorPoint, Color_Stablize, 3 * Time.deltaTime);
            }
            if (is_50)
            {
                New_colorPoint = Color.Lerp(Now_colorPoint, Color_link50, 3 * Time.deltaTime);
            }
            if (is_15)
            {
                New_colorPoint = Color.Lerp(Now_colorPoint, Color_link15, 3 * Time.deltaTime);
            }
        }

    }
    void Get_Color()
    {
        Now_colorPoint = Link_player.color;
    }
    void Set_Coloe()
    {
        Link_player.color = New_colorPoint;
        Link_summoner.color = New_colorPoint;
    }
}
