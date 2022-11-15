using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Events.GamePlaying;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{

    [SerializeField] private PlayerActor _playerActor;
    [SerializeField] private ShiActor _shiActor;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private WeaponPositionActor _weaponPositionActor;
    [SerializeField] private Vine_Actor _vineActor;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe<PlayerAttackDetected>(OnPlayerAttack);//玩家發動攻擊
        EventBus.Subscribe<CallWeaponDetected>(OnCallingWeapon);//玩家召喚替身
        EventBus.Subscribe<PlayerGetHitDetected>(OnPlayerGetHit);
        EventBus.Subscribe<CallBackWeaponDetected>(OnWeaponReturn);//替身回到玩家身邊
        EventBus.Subscribe<HitEnemyDetected>(OnHitEnemy);
        EventBus.Subscribe<PlayerDeadDetected>(OnPlayerDead);
        //EventBus.Subscribe<OnPlayerConnectWeaponDetected>(OnConnect);
        //EventBus.Subscribe<OnPlayerDisConnectDetected>(OnDisConnect);
        
        _playerActor = FindObjectOfType<PlayerActor>();
        _shiActor = FindObjectOfType<ShiActor>();
        _weaponPositionActor = FindObjectOfType<WeaponPositionActor>();
        _vineActor = FindObjectOfType<Vine_Actor>();
        _uiManager = FindObjectOfType<UIManager>();


    }

    /*
    private void OnDisConnect(OnPlayerDisConnectDetected obj)
    {
        
    }

    private void OnConnect(OnPlayerConnectWeaponDetected obj)
    {
        
    }
*/
    void Update()
    {
        
    }

    private void OnHitEnemy(HitEnemyDetected obj)
    {
        ShowHit.instance.GetHit();
    }

    private void OnWeaponReturn(CallBackWeaponDetected obj)
    {
        //Debug.Log("ShiIsBack");
        _weaponPositionActor.WeaPonReset();
    }

    private void OnCallingWeapon(CallWeaponDetected obj)
    {
        //Debug.Log("SummosShi!!");
        _shiActor.SummonsShi();
    }

    private void OnPlayerAttack(PlayerAttackDetected obj)
    {
        Debug.Log("ATTACK!!!");
    }
    
    private void OnPlayerGetHit(PlayerGetHitDetected obj)
    {
        Debug.Log("GetHit!!!");
    }
    
    private void OnPlayerDead(PlayerDeadDetected obj)
    {
        
    }
    
}
