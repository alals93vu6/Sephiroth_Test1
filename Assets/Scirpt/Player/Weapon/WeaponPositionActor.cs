using System.Collections;
using System.Collections.Generic;
using Project;
using UnityEngine;

public class WeaponPositionActor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            EventBus.Post(new CallWeaponDetected());
        }
    }
    
    
}
