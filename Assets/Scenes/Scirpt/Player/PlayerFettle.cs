using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class PlayerFettle : MonoBehaviour
{
    [Header("數值")] 
    [SerializeField] public float MaxHP;
    [SerializeField] public float NowHP;
    
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
        if (NowHP <= 0)
        {
            EventBus.Post(new PlayerDeadDetected());
        }
    }

    public void PlayerGetHit(float GitDamage)
    {
        NowHP -= GitDamage;
    }


    private void HPSet()
    {
        NowHP = MaxHP;
    }
}
