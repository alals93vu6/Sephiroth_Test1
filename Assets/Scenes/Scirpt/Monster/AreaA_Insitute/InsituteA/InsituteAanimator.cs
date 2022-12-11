using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsituteAanimator : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
