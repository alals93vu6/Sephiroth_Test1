using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudioVal : MonoBehaviour
{
    public static float Sound_Val;
    public Scrollbar bar;
    void Update()
    {
        Sound_Val = bar.value;
    }
}
