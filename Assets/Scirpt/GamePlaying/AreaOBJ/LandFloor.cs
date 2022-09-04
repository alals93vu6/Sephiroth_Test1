using System.Collections;
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

    private void WritingDetect()
    {
        if (Physics2D.OverlapBox(DetectArea.transform.position, new Vector2(CubeSizeX, CubeSizeY), 0, PlayerLayer))
        {
            if (NowPlayer.transform.position.y >= this.transform.position.y + 1.2f)
            {
                OnAllowed();
                IsWriting = true;
            }
            else
            {
                OnNotAllowed();
                IsWriting = false;
            }
            Debug.Log("VAR");
        }
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
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void OnNotAllowed()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(DetectArea.transform.position,new Vector2(CubeSizeX,CubeSizeY));
    }
    
    /*
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
        
        
        gameObject.layer = LayerMask.NameToLayer("JumpFloor");
        Debug.Log("UP");
        */
    
}
