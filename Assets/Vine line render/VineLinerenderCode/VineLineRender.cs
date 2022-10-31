using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineLineRender : MonoBehaviour
{
    [SerializeField] private LineRenderer vine_linerender;
    [SerializeField] private Transform first_point;
    [SerializeField] private Transform end_point;
    // Start is called before the first frame update
    void Start()
    {
        vine_linerender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        vine_linerender.SetPosition(0, first_point.position);
        //vine_linerender.SetWidth(.15f, .15f);
        vine_linerender.sortingOrder = 3;
        vine_linerender.sortingLayerName = "Default";
        vine_linerender.SetPosition(1, end_point.position);
    }
}
