using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHit : MonoBehaviour
{
    #region Instance
    static public ShowHit instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private int HP;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void GetHit()
    {
        HP--;
        Debug.Log("Hit");
    }
}
