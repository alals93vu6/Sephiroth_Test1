using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [Header("看向目標")]
    [SerializeField] public GameObject LookAtGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.right = LookAtGameObject.transform.position - this.transform.position;
    }
}
