using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{

    [SerializeField] private PlayerActor _playerActor;
    [SerializeField] private ShiActor _shiActor;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe<PlayerAttackDetected>(OnPlayerAttack);//玩家發動攻擊
        EventBus.Subscribe<CallWeaponDetected>(OnCallingWeapon);//玩家召喚替身
        EventBus.Subscribe<CallBackWeaponDetected>(OnWeaponReturn);//替身回到玩家身邊
        EventBus.Subscribe<HitEnemyDetected>(OnHitEnemy);
        
        _playerActor = FindObjectOfType<PlayerActor>();
        _shiActor = FindObjectOfType<ShiActor>();
        

    }

    void Update()
    {
       /*
        playerActor.connecttest();
       if (playerActor.IsRight == true)
       {
           Debug.Log("R");
       }
       else
       {
           Debug.Log("L");
       }
       */
    }

    private void OnHitEnemy(HitEnemyDetected obj)
    {
        ShowHit.instance.GetHit();
    }

    private void OnWeaponReturn(CallBackWeaponDetected obj)
    {
        //Debug.Log("ShiIsBack");
    }

    private void OnCallingWeapon(CallWeaponDetected obj)
    {
        //Debug.Log("SummosShi!!");
        _shiActor.SummonsShi();
    }

    private void OnPlayerAttack(PlayerAttackDetected obj)
    {
       
    }

    
}
