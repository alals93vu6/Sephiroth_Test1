using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    // Start is called before the first frame update
    public Material VineMaterial;
    [Header("Vinelinerender")]
    [SerializeField] private LineRenderer vine_linerender;
    [Header("主角位置")]
    [SerializeField] private Transform first_point;
    [Header("召喚物位置")]
    [SerializeField] private Transform end_point;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cconcatenation();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vine_length_0();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vine_length_1();
        }

    }
    public void Vine_length_0()
    {
        VineMaterial.SetFloat("VineValue", 0);
    }
    public void Vine_length_1()
    {
        VineMaterial.SetFloat("VineValue", 1);
    }
    void Cconcatenation()
    {
        vine_linerender.SetPosition(0, first_point.position);
        //vine_linerender.SetWidth(.15f, .15f);
        vine_linerender.sortingOrder = 3;
        vine_linerender.sortingLayerName = "Default";
        vine_linerender.SetPosition(1, end_point.position);
    }
}
