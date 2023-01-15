using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Now_pie : MonoBehaviour
{
    [SerializeField] public static float pie_int = 0;
    [SerializeField] public int pie_int_speed = 10;
    [SerializeField] public static bool is_stop_pie = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pie_int);
        set_Pie_int();
        stop_pie();
    }
    void set_Pie_int()
    {
        if (is_stop_pie == false)
        {
            pie_int += Time.deltaTime * pie_int_speed;
            if (pie_int >= 100)
            {
                pie_int = 0;
            }
        }
    }
    void stop_pie()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_stop_pie = true;
        }
    }
}
