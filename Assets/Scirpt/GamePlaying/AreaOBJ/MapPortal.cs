using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private Vector2 portalSize;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(this.transform.position, portalSize, 0, 4096))
        {
            player.transform.position = endPoint.transform.position;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        
        Gizmos.DrawWireCube(this.transform.position,portalSize);
    }
}
