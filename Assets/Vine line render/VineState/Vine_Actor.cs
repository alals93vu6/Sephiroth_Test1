using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Vine_Actor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vine_IState VineState = new Vine_IdeoState();
    //
    [Header("是否連結")]
    [SerializeField] public bool IsCconcatenation = false;
    [SerializeField] public float Vine_time = 0;
    [Header("Vinelinerender")]
    [SerializeField] public LineRenderer vine_linerender;
    [Header("主角位置")]
    [SerializeField] private Transform first_point;
    [Header("召喚物位置")]
    [SerializeField] private Transform end_point;
    [Header("LineRender圖層")]
    [Range(0,20)][SerializeField] private int Vine_linerender_layer;

    [Header("設定藤蔓渲染")]
    [SerializeField] public Material VineMaterial;
    [Header("設定藤蔓長度")]
    [SerializeField] public float Vine_value;
    [Header("設定藤蔓大小")]
    [SerializeField] private float Vine_tilling;
    [Header("設定藤蔓速度")]
    [SerializeField] public float Vine_speed;
    [Header("當前藤蔓長度")]
    [SerializeField] public float Vine_now;




    void Start()
    {
        vine_linerender = GetComponent<LineRenderer>();
        VineMaterial.SetFloat("VineValue", 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vine_value);
        Cconcatenation();
        GetShaderFloat();
        Vine_IsCconcatenation();
        Vine_length();
    }

    public void Vine_IsCconcatenation()
    {
        if (IsCconcatenation == true)
        {
            ChangeState_Vine(new Vine_ideo_stay());
        }
        if (IsCconcatenation == false)
        {
            ChangeState_Vine(new Vine_ideo_nothing());
        }
    }
    public void line_start()
    {
        if (Vine_time >= 0.2f && Vine_value != 0)
        {
            Vine_value = Vine_value - 0.1f;
            Vine_time = 0;
        }
        if (Vine_value == 0)
        {
            Vine_time = 0;
        }
    }


    public void Vine_length()
    {
        VineMaterial.SetFloat("VineValue", Vine_value);
    }
    public void Vine_Start()
    {
        //Debug.Log("isStart");
        Vine_value = Mathf.Lerp(Vine_now, 0f, Vine_speed * Time.deltaTime);
    }
    public void Vine_End()
    {
        //Debug.Log("isEnd");
        Vine_value = Mathf.Lerp(Vine_now, 1f, Vine_speed * Time.deltaTime);
    }
    void GetShaderFloat()
    {
        Vine_now = VineMaterial.GetFloat("VineValue");
    }
    void Cconcatenation() //連結設定
    {
        vine_linerender.SetPosition(0, first_point.position);
        //vine_linerender.SetWidth(.15f, .15f);
        vine_linerender.sortingOrder = Vine_linerender_layer;
        vine_linerender.sortingLayerName = "Default";
        vine_linerender.SetPosition(1, end_point.position);
    }



    public void ChangeState_Vine(Vine_IState nextState)
    {
        VineState.OnExitState_Vine(this);
        nextState.OnEnterState_Vine(this);
        VineState = nextState;
    }
}
