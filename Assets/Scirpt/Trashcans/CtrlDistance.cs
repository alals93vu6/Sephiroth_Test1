using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlDistance : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("狀態")]
    [SerializeField] Rigidbody2D ShiCtrlrig;
    
    [Header("數值")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float XAxis , YAsis;
    [SerializeField] private float CamereX, CamereY;

    public GameObject CamerePos;
    void Start()
    {
        ShiCtrlrig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AccuracyMove();
        MaxDistance();
    }

    private void AccuracyMove()
    {
        XAxis = Input.GetAxisRaw("HorizontalB");
        YAsis = -Input.GetAxisRaw("VerticalB");
        
        ShiCtrlrig.velocity = new Vector2(XAxis , YAsis) * MoveSpeed;
    }

    private void MaxDistance()
    {
        CamereX = CamerePos.transform.position.x;
        CamereY = CamerePos.transform.position.y;

        this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, CamereX - 7.2f, CamereX + 7.2f)
            ,Mathf.Clamp(this.transform.position.y,CamereY - 3f ,CamereY + 3.5f));

    }
}
