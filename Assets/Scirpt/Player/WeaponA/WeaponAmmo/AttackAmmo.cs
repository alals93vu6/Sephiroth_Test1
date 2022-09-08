using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAmmo : MonoBehaviour
{
    [SerializeField] private float AmmoAttackRange;

    [SerializeField] private LayerMask Floor;
    
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

    }

    private void AmmoMove()
    {
        transform.position += transform.up * 0.19f;
    }

    private void DestoryAmmo()
    {
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position,AmmoAttackRange);
    }
}
