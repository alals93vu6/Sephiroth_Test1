using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPos : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform PlayerWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (Player.transform.position + PlayerWeapon.transform.position) / 2;
    }
}
