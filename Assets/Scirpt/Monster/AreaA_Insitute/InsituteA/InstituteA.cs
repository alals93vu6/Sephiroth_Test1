using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstituteA : MonoBehaviour
{

    [Header("數值")] 
    [SerializeField] public float moveSpeed;
    [SerializeField] private float pointTo;
    [SerializeField] private float detectedRange;
    [SerializeField] public Vector3 rightDetected = new Vector3(0, 0, 0);
    [SerializeField] public Vector3 LeftDetected = new Vector3(0, 0, 0);
    
    [Header("物件")]
    [SerializeField] public LayerMask floor;
    [SerializeField] private InsituteAanimator _animator;
    [Header("狀態")] 
    [SerializeField] private Rigidbody2D enemyrig;
    // Start is called before the first frame update
    void Start()
    {
        enemyrig = GetComponent<Rigidbody2D>();
        _animator = FindObjectOfType<InsituteAanimator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyrig.velocity = new Vector2(pointTo * moveSpeed, enemyrig.velocity.y);
        ChanhePointTO();
    }

    private void ChanhePointTO()
    {
        if(!Physics2D.OverlapCircle((transform.position - rightDetected), detectedRange,floor))
        {
            pointTo = -1;
            _animator._spriteRenderer.flipX = false;

        }
        
        if(!Physics2D.OverlapCircle((transform.position - LeftDetected), detectedRange,floor))
        {
            pointTo = 1;
            _animator._spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position - rightDetected,detectedRange);
        Gizmos.DrawWireSphere(this.transform.position - LeftDetected,detectedRange);
    }
    
    
}
