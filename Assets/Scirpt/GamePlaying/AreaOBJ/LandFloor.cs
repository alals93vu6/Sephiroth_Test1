﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LandFloor : MonoBehaviour
{
    [SerializeField] private float CubeSizeX;
    [SerializeField] private float CubeSizeY;

    [SerializeField] private bool IsWriting;
    [SerializeField] private bool ActiveLand;

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
        if (IsWriting)
        {
            OnFloorCross();
        }

        if (!ActiveLand)
        {
            WritingDetect();
            OnFloorCross();
        }
    }

    private async void WritingDetect()
    {
        if (Physics2D.OverlapBox(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY),0,PlayerLayer))
        {
            IsWriting = true;
            
            await Task.Delay(300);
            
            OnAllowed();
            //Debug.Log("ISON");
        }
        else 
        {
            IsWriting = false;
            
            if (this.transform.position.y + 1.5f <= NowPlayer.transform.position.y)
            {
                await Task.Delay(300);
                
                OnAllowed();
            }
            else
            {
                OnNotAllowed();
            }

        }

        /*
        if (NowPlayer.transform.position.y >= this.transform.position.y)
        {
            OnAllowed();
        }
        else
        {
            OnNotAllowed();
        }
        
        */

    }

    private async void OnFloorCross()
    {
        if (Input.GetAxis("VerticalA") <= -0.6f && Input.GetButtonDown("AKey"))
        {
            ActiveLand = true;
            OnNotAllowed();

            await Task.Delay(1000);
            
            OnAllowed();
            ActiveLand = false;
        }
    }
    

    private void OnAllowed()
    {
        Physics2D.IgnoreLayerCollision(12,11,false);
        
    }

    private void OnNotAllowed()
    {
        Physics2D.IgnoreLayerCollision(12,11,true);
        //Debug.Log("Down");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY));
    }
}
