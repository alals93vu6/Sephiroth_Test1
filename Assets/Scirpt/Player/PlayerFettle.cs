using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class PlayerFettle : MonoBehaviour
{
    [Header("數值")] 
    [SerializeField] private float MaxHP;
    [SerializeField] private float NowHP;
    
    [Header("狀態")]
    [SerializeField] private bool HitCD;
    
    
    #region Instance
    static public PlayerFettle instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        HPSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void PlayerGetHit(float GitDamage)
    {
        if (!HitCD)
        {
            NowHP -= GitDamage;
            HitCD = true;
            EventBus.Post(new PlayerGetHitDetected());
            await Task.Delay(1000);

            HitCD = false;
        }
    }


    private void HPSet()
    {
        NowHP = MaxHP;
    }
}
