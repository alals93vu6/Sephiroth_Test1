using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe<PlayerAttackDetected>(OnPlayerAttack);//玩家發動攻擊
        EventBus.Subscribe<PlayerCallShiDetected>(OnCallingShi);//玩家召喚替身
        EventBus.Subscribe<ShiReturnDetected>(OnShiReturn);//替身回到玩家身邊
        EventBus.Subscribe<HitEnemyDetected>(OnHitEnemy);
    }

    private void OnHitEnemy(HitEnemyDetected obj)
    {
        ShowHit.instance.GetHit();
    }

    void Update()
    {
        
    }
    private void OnShiReturn(ShiReturnDetected obj)
    {
        //Debug.Log("ShiIsBack");
    }

    private void OnCallingShi(PlayerCallShiDetected obj)
    {
        //Debug.Log("SummosShi!!");
    }

    private void OnPlayerAttack(PlayerAttackDetected obj)
    {
        throw new System.NotImplementedException();
    }

    
}
