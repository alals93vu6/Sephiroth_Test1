using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstituteA : MonoBehaviour
{

    [Header("數值")] 
    [SerializeField] public float moveSpeed;
    [SerializeField] private float pointTo;
    [SerializeField] private float detectedRange;
    private float movetime;
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
        movetime += Time.deltaTime;
        ChanhePointTO();
    }

    private void ChanhePointTO()
    {
        if(!Physics2D.OverlapCircle((transform.position - rightDetected), detectedRange,floor))
        {
            pointTo = -1;
            transform.localScale = new Vector3(1, 1, 1);
            movetime = 0;
        }
        
        if(!Physics2D.OverlapCircle((transform.position - LeftDetected), detectedRange,floor))
        {
            pointTo = 1;
            transform.localScale = new Vector3(-1, 1, 1);
            movetime = 0;
        }
        
        if (movetime >= 5)
        {
            movetime = 0;
            if (pointTo == 1)
            {
                pointTo = -1;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                pointTo = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position - rightDetected,detectedRange);
        Gizmos.DrawWireSphere(this.transform.position - LeftDetected,detectedRange);
    }
    
    
}
