using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_pie : MonoBehaviour
{
    public Image[] pie_chart;
    public float[] values;
    // Start is called before the first frame update
    void Start()
    {
        setvaluse(values);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void setvaluse(float[] ValueToSet)
    {
        float totalvalues = 0;
        for (int i = 0; i < pie_chart.Length; i++)
        {
            totalvalues += Find_pie(ValueToSet, i);
            pie_chart[i].fillAmount = totalvalues;
        }
    }
    private float Find_pie(float[] ValueToSet, int index)
    {
        float totalAmount = 0;
        for (int i = 0; i < ValueToSet.Length; i++)
        {
            totalAmount += ValueToSet[i];
        }
        return ValueToSet[index] / totalAmount;
    }
}
