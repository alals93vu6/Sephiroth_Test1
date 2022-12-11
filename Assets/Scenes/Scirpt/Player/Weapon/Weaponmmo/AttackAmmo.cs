using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using UnityEngine;

public class AttackAmmo : MonoBehaviour
{
    [SerializeField] private float AmmoAttackRange;

    [SerializeField] private LayerMask Floor;

    [SerializeField] private LayerMask Enemy;

    private bool HitCD;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestoryAmmo",5f);
    }

    // Update is called once per frame
    void Update()
    {
        AmmoMove();
        if (Physics2D.OverlapCircle(this.transform.position,AmmoAttackRange,Floor))
        {
            DestoryAmmo();
        }
        
        if (Physics2D.OverlapCircle(this.transform.position,AmmoAttackRange,Enemy) && !HitCD)
        {
            HitEnemy();
            DestoryAmmo();
        }

    }

    private void AmmoMove()
    {
        transform.position += transform.up * 0.19f;
    }

    private void DestoryAmmo()
    {
        Destroy(this.gameObject);
    }

    private async void HitEnemy()
    {
        EventBus.Post(new HitEnemyDetected());
        Debug.Log("HitA");
        HitCD = true;

        await Task.Delay(1500);

        HitCD = false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position,AmmoAttackRange);
    }
}
