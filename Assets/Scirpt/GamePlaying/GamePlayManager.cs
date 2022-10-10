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
        EventBus.Subscribe<CallWeaponDetected>(OnCallingShi);//玩家召喚替身
        EventBus.Subscribe<CallBackWeaponDetected>(OnShiReturn);//替身回到玩家身邊
        EventBus.Subscribe<HitEnemyDetected>(OnHitEnemy);
        
        
    }

    void Update()
    {
       GameObject.Find("PlayerTest").GetComponent<PlayerActor>().connecttest();
    }

    private void OnHitEnemy(HitEnemyDetected obj)
    {
        ShowHit.instance.GetHit();
    }

    private void OnShiReturn(CallBackWeaponDetected obj)
    {
        //Debug.Log("ShiIsBack");
    }

    private void OnCallingShi(CallWeaponDetected obj)
    {
        //Debug.Log("SummosShi!!");
    }

    private void OnPlayerAttack(PlayerAttackDetected obj)
    {
       
    }

    
}
