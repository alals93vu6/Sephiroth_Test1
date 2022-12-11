using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTest : MonoBehaviour
{
    private Rigidbody2D Treerig;

    [SerializeField] private float MaxX;
    [SerializeField] private float MinX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Treerig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        treeMove();

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, MinX, MaxX),this.transform.position.y,0);

    }

    private void treeMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Treerig.velocity = new Vector2 (1 * 0.4f, Treerig.velocity.y);
        }
        else
        {
            Treerig.velocity = Vector2.zero;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Treerig.velocity = new Vector2 (-1 * 0.4f, Treerig.velocity.y);
        }
        else
        {
            Treerig.velocity = Vector2.zero;
        }
    }
}
