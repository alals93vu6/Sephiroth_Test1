using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_SetSound : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("設定生成")]
    [SerializeField] public GameObject SetSound;
    static bool is_set = true;
    void Start()
    {
        if (is_set)
        {
            Instantiate(SetSound);
            is_set = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
