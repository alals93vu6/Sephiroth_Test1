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
    }

    private void OnPlayerAttack(PlayerAttackDetected obj)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
