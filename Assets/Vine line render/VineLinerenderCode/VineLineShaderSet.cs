using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineLineShaderSet : MonoBehaviour
{
    [Header("設定藤蔓渲染")]
    [SerializeField] private Material VineMaterial;
    [Header("設定藤蔓伸縮")]
    [SerializeField] private float Vine_value;
    [Header("設定藤蔓大小")]
    [SerializeField] private float Vine_tilling;
    [Header("是否連接")]
    [SerializeField] bool isStartConcatenation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void StartConcatenation()
    {
        VineMaterial.SetFloat("VineValue", 1);
        
    }
    void StayConcatenation()
    {

    }
    void EndConcatenation()
    {

    }
}
