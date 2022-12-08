using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetAudio :  MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("設定音樂")]
    [SerializeField] public List<AudioClip> Setaudio = new List<AudioClip>();
    [Header("呼叫音效編號")]
    [SerializeField] public static int audioNum = 0;
    [Header("設定音效物件")]
    [SerializeField]public AudioSource BGM_Audio;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        BGM_Audio.clip = Setaudio[audioNum];
        BGM_Audio.volume = SetAudioVal.Sound_Val;
        Debug.Log(BGM_Audio.volume);
    }
}
