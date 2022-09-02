using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandFloor : MonoBehaviour
{
    [SerializeField] private float CubeSizeX;
    [SerializeField] private float CubeSizeY;

    [SerializeField] private bool IsWriting;

    [SerializeField] private LayerMask PlayerLayer;

    [SerializeField] private GameObject DetectArea;
    [SerializeField] private GameObject NowPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WritingDetect();
        OnFloorCross();
    }

    private void WritingDetect()
    {
        if (Physics2D.OverlapBox(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY),PlayerLayer))
        {
            IsWriting = true;
        }
        else
        {
            IsWriting = false;
        }

        if (NowPlayer.transform.position.y >= this.transform.position.y)
        {
            OnAllowed();
        }
        else
        {
            OnNotAllowed();
        }

    }

    private void OnFloorCross()
    {
        if (IsWriting)
        {
            
        }
    }

    private void OnAllowed()
    {
        Physics2D.IgnoreLayerCollision(12,11,false);
        Debug.Log("UP");
    }

    private void OnNotAllowed()
    {
        Physics2D.IgnoreLayerCollision(12,11,true);
        Debug.Log("Down");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY));
    }
}
